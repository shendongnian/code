    private string destination;
    public void buttonSaveTo_Click(object sender, EventArgs e)
    {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            richTextBox1.Text = fbd.SelectedPath;
            destination = fbd.SelectedPath;
    }
    
    webClient.DownloadFile("http://i.imgur.com/" + picture, System.IO.Path.Combine(destionation, picture));
