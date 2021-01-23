    namespace MyNamespace {
        public class MyWebServiceClass {
            private const string DESCRIPTION = "Locate Enrichment XML Doc";
            [WebMethod(MessageName = "EnrichmentXml", Description = DESCRIPTION)]
            public XmlDocument EnrichmentXml(string xmlRequest)
            {
                SaveLog(DESCRIPTION + " method was called.");
            }
        }
    }
