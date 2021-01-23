    private void button1_Click(object sender, EventArgs e)
    {
        string url = @"DOWNLOADLINK";
        WebClient web = new WebClient();
        try 
        {
            web.DownloadFile(new Uri(url), @"F:\a");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
