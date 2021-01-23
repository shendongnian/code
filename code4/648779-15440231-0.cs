    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Web;
    using WebKit;
    
    namespace test_run
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                wkb.DocumentText = @"
                    <!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.01//EN' 'http://www.w3.org/TR/html4/strict.dtd'>
                    <html>
                    <head></head>
                    <body>
                    <form method='get'>
                    <input type='text' name='pike'><br>
                    <input type='submit' value='Submit'>
                    </form>
                    </body>
                    </html>";
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
            }
    
            private void wkb_navigating(object sender, WebKitBrowserNavigatingEventArgs e)
            {
                string param1 = HttpUtility.ParseQueryString(e.Url.ToString()).Get(0);
                MessageBox.Show(param1.ToString());
            }
        }
    }
