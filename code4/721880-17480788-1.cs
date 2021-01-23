    public string DictJSON
    {
        get { 
            JavaScriptSerializer jSer = new JavaScriptSerializer();
            return jSer.Serialize(dict);
        }
    }
