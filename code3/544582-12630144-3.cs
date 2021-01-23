    private void button1_Click(object sender, EventArgs e)
    {
        string url = @"DOWNLOADLINK";
        WebClient web = new WebClient();
        if (Directory.Exists("f:\\a"))
        {
            MessageBox.Show("f:\\a is a directory, not a file. Specify a filename.");
            return;
        }
        if (File.Exists("f:\\a"))
        {
            MessageBox.Show("f:\\a is a file that already exists. Delete or rename it, or specifiy a different file name.");
            return;
        }
        try 
        {
            web.DownloadFile(new Uri(url), @"F:\a");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
