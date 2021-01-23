    WebClient client = new WebClient();
    client.Encoding = System.Text.Encoding.UTF8;
    
    string reply = client.DownloadString("http://abc.com");
    
    TextBox1.Text = reply;
