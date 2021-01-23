    var links = textBox1.Text.Split(new string[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
    foreach (var link in links) {
        if (IsNotWorking(link)) {
            //do something here
        }
    }
    bool IsNotWorking(string url) {
        HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(url);
        //You can set some parameters in the "request" object...
        request.AllowAutoRedirect = true;
        
        HttpWebResponse response = (HttpWebResponse) request.GetResponse();
        try
        {
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                //Perhaps you don't need the below line...
                reader.ReadToEnd();
                return true;
            }
        }
        catch //TODO: Check for the right exception here
        {
            return false;
        }
    }
