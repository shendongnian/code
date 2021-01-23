    hello i try this it works ( I make a console application and I add a windows form)
    
        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Permissions;
    using System.Windows.Forms;
    
    namespace ConsoleApplication6
    {
        class Program
        {
             
             delegate void SetTextCallback(string s);
             static Form1 f;
       
            static void Main(string[] args)
            {      
                 f = new Form1();
                 f.Show();
                 SetText("test");
                Console.ReadLine();
            }
            private static void SetText(string text)
            {
                // InvokeRequired required compares the thread ID of the 
                // calling thread to the thread ID of the creating thread. 
                // If these threads are different, it returns true. 
                if (f.textBox1.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    f.textBox1.Invoke(d, new object[] { text });
                }
                else
                {
                    f.textBox1.AppendText(text);
                }
            }
        }
     
    }
