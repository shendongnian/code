    public JObject GetThat()
    {
        HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
        string phpResponse = string.Empty;
        using(StreamReader rdr = new StreamReader(WebResp.GetResponseStream()))
            phpResponse = rdr.ReadToEnd();
        }
        JObject myResult = JObject.Parse(phpResponse);
        return myResult;
    }
