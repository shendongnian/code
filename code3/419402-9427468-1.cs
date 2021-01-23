            public void AddAdvancedSearchProperty()
        {
            string sourcefile =
                string.Format(
                    "{0}\\{1}", SPUtility.GetGenericSetupPath("TEMPLATE\\ADMIN\\ManagedProperties"), "NewAdvancedSearchProperty.xml");
            // Load the xml file into XmlDocument object.
            var xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(sourcefile);
            }
            catch (XmlException e)
            {
                Console.WriteLine(e.Message);
            }
            // Now create StringWriter object to get data from xml document.
            var sw = new StringWriter();
            var xw = new XmlTextWriter(sw);
            xmlDoc.WriteTo(xw);
            string newXmlString = sw.ToString();
            using (var sc = new SPSite("YOUR SITE"))
            {
                using (SPWeb web = sc.OpenWeb("searchcentre"))
                {
                    SPLimitedWebPartManager mgr = web.GetLimitedWebPartManager("pages/advanced.aspx", PersonalizationScope.Shared);
                    foreach (var wp in mgr.WebParts)
                    {
                        if (wp is AdvancedSearchBox)
                        {
                            var asb = wp as AdvancedSearchBox;
                            asb.Properties = newXmlString;
                            mgr.SaveChanges(asb);
                        }
                    }
                    mgr.Web.Dispose();
                }
            }
        }
