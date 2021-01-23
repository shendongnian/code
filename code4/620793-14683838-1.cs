    private void Form_Load(object sender, EventArgs e) {
        using (System.Net.WebClient wc = new System.Net.WebClient()) {
            richTextBox.Text = wc.DownloadString("http://www.google.com");
        }
    }
