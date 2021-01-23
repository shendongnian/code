    using System;  
    using System.Collections.Generic;  
    using System.ComponentModel;  
    using System.Data;  
    using System.Drawing;  
    using System.Windows.Forms;  
      
    namespace Auto_Complete_Brackets  
    {  
        public partial class Form1 : Form  
        {  
            public Form1()  
            {  
                InitializeComponent();  
            }  
      
            //declare  isCurslyBracesKeyPressed variable as Boolean and assign false value  
            //to check { key is pressed or not  
            public static Boolean isCurslyBracesKeyPressed = false;  
      
            //richTextBox1 KeyPress events  
      
            // if key (,{,<,",',[ is pressed then insert opposite key to richTextBox1 at Position SelectionStart+1  
            // add one line after inserting, e.Handled=true;  
            //finally set SelectionStart to specified position  
      
            private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)  
            {  
                String s = e.KeyChar.ToString();  
                int sel = richTextBox1.SelectionStart;  
                if (checkBox1.Checked == true)  
                {  
                    switch (s)  
                    {  
                        case "(": richTextBox1.Text = richTextBox1.Text.Insert(sel, "()");  
                            e.Handled = true;  
                            richTextBox1.SelectionStart = sel + 1;  
                            break;  
      
                        case "{":  
                            String t = "{}";  
                            richTextBox1.Text = richTextBox1.Text.Insert(sel, t);  
                            e.Handled = true;  
                            richTextBox1.SelectionStart = sel + t.Length - 1;  
                            isCurslyBracesKeyPressed = true;  
                            break;  
      
                        case "[": richTextBox1.Text = richTextBox1.Text.Insert(sel, "[]");  
                            e.Handled = true;  
                            richTextBox1.SelectionStart = sel + 1;  
                            break;  
      
                        case "<": richTextBox1.Text = richTextBox1.Text.Insert(sel, "<>");  
                            e.Handled = true;  
                            richTextBox1.SelectionStart = sel + 1;  
                            break;  
      
                        case "\"": richTextBox1.Text = richTextBox1.Text.Insert(sel, "\"\"");  
                            e.Handled = true;  
                            richTextBox1.SelectionStart = sel + 1;  
                            break;  
      
                        case "'": richTextBox1.Text = richTextBox1.Text.Insert(sel, "''");  
                            e.Handled = true;  
                            richTextBox1.SelectionStart = sel + 1;  
                            break;  
                    }  
                }  
            }  
      
      
            // richTextBox1 Key Down event  
            /* 
             * when key  {  is pressed and {} is inserted in richTextBox 
             * and isCurslyBracesKeyPressed is true then insert some blank text to richTextBox1 
             * when Enter key is down 
             * it will look like this when Enter key is down 
              
                 { 
                       | 
                 }         
               
             * */  
      
            private void richTextBox1_KeyDown(object sender, KeyEventArgs e)  
            {  
                int sel = richTextBox1.SelectionStart;  
                if (e.KeyCode == Keys.Enter)  
                {  
                    if(isCurslyBracesKeyPressed==true)  
                    {  
                        richTextBox1.Text = richTextBox1.Text.Insert(sel, "\n          \n");  
                        e.Handled = true;  
                        richTextBox1.SelectionStart = sel + "          ".Length;  
                        isCurslyBracesKeyPressed = false;  
                    }  
                }  
            }  
        }  
    }  
