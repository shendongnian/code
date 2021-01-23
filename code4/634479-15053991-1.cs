    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                webBrowser1.Navigate("about:blank");
                webBrowser1.Document.Write("<html><head><style>html, body{{padding:0; margin:0 }}</style></head><body><div id='divMain'>&nbsp;</div></body></html>");
            }
    
    
            private void button1_Click(object sender, EventArgs e)
            {
                Random r = new Random();
                int number = 0;
                number = r.Next(0, 999999);
                string captcha = "<img src=\"http://www.reddit.com/captcha/{0}.png\"></img>";
    
                webBrowser1.Document.GetElementById("divMain").InnerHtml = string.Format(captcha, number);
            }
        }
    }
