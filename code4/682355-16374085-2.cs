        HttpWebRequest myHttpWebRequest = null;     //Declare an HTTP-specific implementation of the WebRequest class.
            HttpWebResponse myHttpWebResponse = null;   //Declare an HTTP-specific implementation of the WebResponse class
            XmlDocument myXMLDocument = null;           //Declare XMLResponse document
            XmlTextReader myXMLReader = null;           //Declare XMLReader
            try
            {
                //Create Request
                myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create("http://www.xe.com/wap/2co/convert.cgi?Amount=100&From=SGD&To=HUF");
                myHttpWebRequest.Method = "GET";
                myHttpWebRequest.ContentType = "text/xml; encoding='utf-8'";
                //Get Response
                myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                //Now load the XML Document
                myXMLDocument = new XmlDocument();
                //Load response stream into XMLReader
                myXMLReader = new XmlTextReader(myHttpWebResponse.GetResponseStream());
                myXMLDocument.Load(myXMLReader);
            }
            catch (Exception myException)
            {
                throw  myException;
            }
            finally
            {
                myHttpWebRequest = null;
                myHttpWebResponse = null;
                myXMLReader = null;
            }
