    [WebMethod]
    public string LoadLayout()
    {
        try
        {
            List<XmlTag> lstXmlTags = parser.GetXmlTags(filePath);
            var serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(lstXmlTags);
            string script = string.Format("alert(JSON.stringify({0}));", json);
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "test", script, true);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
