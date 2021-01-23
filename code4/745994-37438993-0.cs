        public class CustomXmlMediaTypeFormatter : XmlMediaTypeFormatter
        {
            public CustomXmlMediaTypeFormatter()
            {
                UseXmlSerializer = true;
                WriterSettings.OmitXmlDeclaration = false;
            }
        }
