using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SmileyJSON
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ButtonOlustur();
        }

        private void ButtonOlustur()
        {

            List<JsonHelper> lst = GetAllData();

            
            foreach (var item in GetAllData())
            {
             
                Button btn = new Button();
                btn.Name = "btn_" + item.category;
                btn.Text = item.category;
                btn.Click += btnClick;

                flowLayoutPanel1.Controls.Add(btn);
                foreach (var x in item.items)
                {
                    
                    string y = x.art.ToString();
                    y += Environment.NewLine;
                    y += x.name.ToString();
                    Button btn1 = new Button();
                    btn1.Text = y;
                    btn1.Height = 100;
                    flowLayoutPanel2.Controls.Add(btn1);

                }
              

            }
        }

        private void btnClick(object sender, EventArgs e)
        {
           
        }

        public List<JsonHelper> GetAllData()
        {
            string deger = File.ReadAllText("../../smiley_content.json");
            JavaScriptSerializer jss = new JavaScriptSerializer();
           List<JsonHelper> lst =  jss.Deserialize<List<JsonHelper>>(deger);
            return lst;
        }
    }
}
