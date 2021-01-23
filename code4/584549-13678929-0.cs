    private void Button1_Click(object sender, System.EventArgs e)
    {
    WebClient webClient = new WebClient(); 
    const string strUrl = "http://www.yahoo.com/"; 
    byte[] reqHTML; 
    reqHTML = webClient.DownloadData(strUrl); 
    UTF8Encoding objUTF8 = new UTF8Encoding(); 
    lblWebpage.Text = objUTF8.GetString(reqHTML); 
    
    }
