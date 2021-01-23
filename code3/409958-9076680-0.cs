    public static class XmlUtils {
      public static XmlDocument CreateDocument(string xml) {
        var doc = new XmlDocument();
        doc.LoadXml(xml);
        return doc;
      }
    }
    var doc = XmlUtils.CreateDocument("<XMLHERE/>");
