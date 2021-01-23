    public bool isValid(string url) {
        Stream sStream;
        HttpWebRequest urlReq;
        HttpWebResponse urlRes;
        try {
            urlReq = (HttpWebRequest) WebRequest.Create(url);
            urlRes = (HttpWebResponse) urlReq.GetResponse();
            sStream = urlRes.GetResponseStream();
     
            string read = new StreamReader(sStream).ReadToEnd();
            return true;
            
        } catch (Exception ex) {
            //Url not valid
            return false;
        }
    }
