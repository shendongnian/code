       using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public string rtbTypedText = "";
            public Form1()
            {
                InitializeComponent();
            }
    
           
    
            
    
            private void richTextBox1_Leave(object sender, EventArgs e)
            {
               
    
               // MessageBox.Show(text);
    
            }
    
            private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (char.IsWhiteSpace(e.KeyChar))
                {
                    int result = 0;
                    string s = richTextBox1.Text;
    
                    string text = "";
                    string[] sp = s.Split(' ');
    
                    if (sp.Length == 0)
                        rtbTypedText = s;
                    else
                        rtbTypedText = sp[sp.Length - 1];
    
    
                    bool typeStatus = int.TryParse(rtbTypedText, out result);
                    if (typeStatus == true)
                        toolTip1.Show("It is a Number", richTextBox1);
                    else
                        toolTip1.Show("It is an Alphabet", richTextBox1);
                }
    
            }
        }
    }
