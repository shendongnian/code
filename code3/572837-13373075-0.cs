    [WebInvoke(UriTemplate = "UpdateFile/{id}", Method = "POST")]
    public bool UpdateTestXMLFile(string id, Stream createdText)
    {
       DataSet ds = new DataSet(); 
       ds.ReadXml(createdText)
      
       string filenamewithpath = System.Web.HttpContext.Current.Server.MapPath(@"~/files/" + id+".xml");
       ds.WriteXml(filenamewithpath);      
    }
