    public void Button_Click(object sender, EventArgs e)
    {
        HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
        req.Method = "GET";
        req.BeginGetResponse(HWRCallback, req);
    }
    void HWRCallback(IAsyncResult ar)
    {
        HttpWebRequest req = (HttpWebRequest)ar.AsyncState;
        HttpWebResponse resp = (HttpWebResponse)req.EndGetResponse(ar);
        // use response
    }
