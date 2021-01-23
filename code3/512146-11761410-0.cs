    private void login_Click(object sender, EventArgs e)
    {
        string username = uname.Text;
        string password = pword.Text;
        string url = "THE SITE URL HERE";
        var req = (HttpWebRequest)WebRequest.Create(url);
        req.Credentials = new NetworkCredential(username, password);
        var response = req.GetResponse();
        //Do Stuff with response
    }
