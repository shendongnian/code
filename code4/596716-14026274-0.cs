    public static string csrf;
    CookieContainer c1 = new CookieContainer();
    private void button1_Click(object sender, EventArgs e)
    {
        string PostData = String.Format("csrfmiddlewaretoken={0}&username=ra123&password=ra12345678", getToken());
        HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://instagram.com/accounts/login/");
        req.Method = "POST";
        req.ContentType = "application/x-www-form-urlencoded";
        req.KeepAlive = true;
        req.AllowAutoRedirect = true;
        req.CookieContainer = c1;
        byte[] byteArray = Encoding.ASCII.GetBytes(PostData);
        req.ContentLength = byteArray.Length;
        using (Stream dataStream = req.GetRequestStream())
        {
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Flush();
            dataStream.Close();
        }
        string s;
        using (HttpWebResponse webResp = (HttpWebResponse)req.GetResponse())
        {
            using (Stream datastream = webResp.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(datastream))
                {
                    s = reader.ReadToEnd();
                }
            }
        }
        MessageBox.Show(s);
        if (s.Contains("ra123"))
        {
            MessageBox.Show("Loggedin");
        }
        else
        {
            MessageBox.Show("Not");
        }
    }
    string getToken()
    {
        string p = "<input type=\"hidden\" name=\"csrfmiddlewaretoken\" value=\"(.*)\"/>";
        HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://instagram.com/accounts/login/");
        req.Method = "GET";
        req.CookieContainer = c1;
        string src;
        using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
        {
            using (Stream data = resp.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(data))
                {
                    src = sr.ReadToEnd();
                }
            }
        }
        Match m = Regex.Match(src, p);
        if (m.Success)
        {
            return (m.Groups[1].Value.ToString());
        }
        return false.ToString();
    }
