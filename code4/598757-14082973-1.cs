    using System;
    using System.Windows.Forms;
     
    class Program 
    {
        [STAThread]
        static void Main(string[] args) 
        {
             Clipboard.SetText("this is in clipboard now");
        }
    }
