    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                if(webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                {
                    timer1.Enabled = false;
                    richTextBox1.Text = webBrowser1.DocumentText;
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                timer1.Enabled = true;
                webBrowser1.Navigate("http://www.google.com");
            }
        }
