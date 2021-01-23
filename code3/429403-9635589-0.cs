        public enum Log4NetConfigItem
        {
            LOGLEVEL
        }
        public const string LOG4NET_CONFIGFILE = "log4net.config";
        public void UpdateConfiguration(Log4NetConfigItem which, object value)
        {
            // Load the config file.
            XmlDocument doc = new XmlDocument();
            doc.Load(LOG4NET_CONFIGFILE);
            // Create an XPath navigator for the document.
            XPathNavigator nav = doc.CreateNavigator();
            try
            {
                XPathExpression expr;
                // Compile the correct XPath expression for the element we want to configure.
                switch (which)
                {
                    default:
                    case Log4NetConfigItem.LOGLEVEL:
                        // Compile a standard XPath expression
                        expr = nav.Compile("/configuration/log4net/logger/level");
                        break;
                }
                // Locate the node(s) defined by the XPath expression.
                XPathNodeIterator iterator = nav.Select(expr);
                // Iterate on the node set
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    // Update the element as required.
                    switch (which)
                    {
                        default:
                        case Log4NetConfigItem.LOGLEVEL:
                            // Update the 'value' attribute for the log level.
                            SetAttribute(nav2, String.Empty, "value", nav.NamespaceURI, value.ToString());
                            break;
                    }
                }
                // Save the modified config file.
                doc.Save(LOG4NET_CONFIGFILE);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
        void SetAttribute(System.Xml.XPath.XPathNavigator navigator, String prefix, String localName, String namespaceURI, String value)
        {
            if (navigator.CanEdit == true)
            {
                // Check if given localName exist
                if (navigator.MoveToAttribute(localName, namespaceURI))
                {
                    // Exist, so set current attribute with new value.
                    navigator.SetValue(value);
                    // Move navigator back to beginning of node
                    navigator.MoveToParent();
                }
                else
                {
                    // Does not exist, create the new attribute
                    navigator.CreateAttribute(prefix, localName, namespaceURI, value);
                }
            }
        }
