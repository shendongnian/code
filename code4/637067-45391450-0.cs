    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace ShowAllSaveNameAndCountApp
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            List<string> ourList=new List<string>();
            
    
            string txt =" ";
            private void buttonSave_Click(object sender, EventArgs e)
            {
                ourList.Add(textBoxEntryName.Text);
    
    
                
                foreach (string s in ourList)
                {
                    txt+= s+ "\n ";
                    
                    
                }
                textBoxEntryName.Clear();
                
               ourList.Clear();
    
    
            }
    
    
    
            private void buttonShowAllName_Click(object sender, EventArgs e)
            {
                textBoxShowName.Text = txt;
            }
        }
    }
