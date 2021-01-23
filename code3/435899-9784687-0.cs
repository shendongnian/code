                    public interface IXDocument
                    {
                        XDocument GetDocument(string str);
                    }
                    public interface IXMLDocument
                    {
                        XMLDocument GetDocument(string str);
                    }
              
                public class Document : IXDocument, IXMLDocument
                {
                    public XDocument IXDocument.GetDocument(string str)
                    {
                        // return XDocument
                    }
                    public XMLDocument IXMLDocument.GetDocument(string str)
                    {
                        // return XMLDocument
                    }
                }
                XDocument returnedXDocument = ((IXDocument)Instance of Docuement).GetDocument("value");
                // - and/or
                XMLDocument returnedXMLDocument = ((IXMLDocument)Instance of Docuement).GetDocument("value");
