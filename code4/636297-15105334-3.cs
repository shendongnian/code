    var links = textBox1.Text.Split(new string[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
    foreach (var link in links) {
        if (!IsLinkWorking(link)) {
            //Here you can show the error. You don't specify how you want to show it.
            textBox2.Text += string.Format("Link {0} not working\n", link);
        }
    }
    bool IsLinkWorking(string url) {
        HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(url);
        //You can set some parameters in the "request" object...
        request.AllowAutoRedirect = true;
        
        try {
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            return true;
        } catch { //TODO: Check for the right exception here
            return false;
        }
    }
