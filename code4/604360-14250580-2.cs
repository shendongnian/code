    using (XmlReader reader = XmlReader.Create(new StringReader(Response)))
    {
        reader.ReadToFollowing("response");
    
        reader.ReadToFollowing("status");
        string status = reader.ReadElementContentAsString();
        if (status == "ok")
        {
            reader.ReadToFollowing("number");
            string orderNo = reader.ReadElementContentAsString();
            HttpContext.Current.Session["orderNo"] = orderNo;
        }
    }
