        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                WebBrowser wb = new WebBrowser();
                wb.DocumentCompleted += wb_DocumentCompleted;
                wb.Navigate("http://www.stackoverflow.com");
            }
        }
        bool shown = false;
        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!shown)
            {
                Console.WriteLine(shown);
                MessageBox.Show(shown.ToString());
                shown = true;
            }
        }
