    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Text.RegularExpressions;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
    
            private void Form1_Load(object sender, EventArgs e)
            {
                MatchCollection mc = Regex.Matches(richTextBox1.Text, @"(www[^ \s]+|http[^ \s]+)([\s]|$)", RegexOptions.IgnoreCase);
    
                for (int collection = 0; collection < mc.Count; collection++)
                {
                    if (richTextBox1.Find(mc[collection].Value, RichTextBoxFinds.None) > -1)
                    {
                        richTextBox1.SelectionProtected = true;
                    }
                }
    
            }
        }
    }
