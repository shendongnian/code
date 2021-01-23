    var links = textBox1.Text.Split(new string[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
    foreach (var link in links) {
        if (!IsLinkWorking(link)) {
            //do something here
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
