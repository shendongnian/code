    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                list = new List<string>();
            }
    
            List<string> list;
    
            private void button1_Click(object sender, EventArgs e)
            {
                list.Add(textBox1.Text);
    
    
                string txt = "";
                foreach(string s in list)
                {
                    txt += s + " ";
                }
                textBox2.Text = txt;
            }
        }
    }
