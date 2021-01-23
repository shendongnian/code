    private void AddTag_Click(object sender, EventArgs e)
    {
        string uriAddTagtoGroup = 
           string.Format("http://localhost:8000/Service/AddTagtoGroup/{0}/{1}",
              textBox6.Text, textBox7.Text);
        RequestResponse(uriAddTagtoGroup)
    }
    private void RequestResponse(string uriAddTagtoGroup)
    {
        byte[] arr = Encoding.UTF8.GetBytes(uriAddTagtoGroup);
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uriAddTagtoGroup);
        req.Method = "POST";
        req.ContentType = "application/xml";
        req.ContentLength = arr.Length;
        using(Stream reqStrm = req.GetRequestStream())
        {
           reqStrm.Write(arr, 0, arr.Length);
        }
        using(HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
        {
           MessageBox.Show(resp.StatusDescription);
        }
    }
