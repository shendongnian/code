     WebClient web = new WebClient();
    try{
        byte[] response = web.DownloadData("http://" + ip +"/test.php");
        webBrowser1.DocumentText = System.Text.ASCIIEncoding.ASCII.GetString(response);
    }
    catch(Exception e)
    {
        MessageBox.Show("Download failed");
    }
