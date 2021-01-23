    private void button1_Click(object sender, EventArgs e)
    {
        string url = @"DOWNLOADLINK";
        WebClient web = new WebClient();
        web.DownloadFile(new Uri(url), @"F:\a");
        MessageBox.Show("The file has been downloaded");
    }
