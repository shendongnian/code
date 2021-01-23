    namespace CSharpWindowsPractice
    {
        using System;
        using System.Windows.Forms;
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
            {
                this.listBox1.Items.Add("Navigated to: " + e.Url);
            }
            private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
            {
                this.listBox1.Items.Add("Navigating to: " + e.Url);
            }
            private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                this.listBox1.Items.Add("DocumentCompleted: " + e.Url);
            }
            private void button1_Click(object sender, EventArgs e)
            {
                this.webBrowser1.Navigate(new Uri(@"http://google.com"));
            }
        }
    }
