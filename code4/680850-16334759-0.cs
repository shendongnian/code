    public static void SaveXML(XPathNodeIterator nodes)
    {
      foreach (XPathNavigator node in nodes)
      {
        using (XmlWriter xw = XmlWriter.Create(HttpContext.Current.Server.MapPath("~/App_Data/missing_data.xml")))
        {
           node.WriteSubtree(xw);
        }
      }
    }
