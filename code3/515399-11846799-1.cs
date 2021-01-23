    public string Url { get; set; }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(this.Url);
        }
