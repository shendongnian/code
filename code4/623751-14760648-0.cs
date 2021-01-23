    namespace WindowsFormsApplication1
    {
        using System;
        using System.Windows.Forms;
        using WatiN.Core;
        public partial class Form1 : System.Windows.Forms.Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                   IE testIE = new IE("http://www.google.com");
                   //FireFox testFF = new FireFox("http://www.google.com");
                }
                catch (Exception exc)
                {
                   MessageBox.Show(exc.Message);
                }
             }
         }
     }
  
