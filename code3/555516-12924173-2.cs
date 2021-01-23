            //get the text of the file into a string
            System.IO.StreamReader sr = new System.IO.StreamReader(@"C:\test.xml");
            String xmlText = sr.ReadToEnd();
            sr.Close();  
            //Create a List of strings and call the method
            List<String> urls = readXMLDoc(_xmlText);
            //check to see if we have a list
            if (urls != null)
            {
                //do somthing
            }
        private List<String> readXMLDoc(String fileText)
        {
            //create a list of Strings to hold our Urls
            List<String> urlList = new List<String>();
            try
            {
                //create a XmlDocument Object
                XmlDocument xDoc = new XmlDocument();
                //load the text of the file into the XmlDocument Object
                xDoc.LoadXml(fileText);
                //Create a XmlNode object to hold the root node of the XmlDocument
                XmlNode rootNode = null;
                //get the root element in the xml document
                for (int i = 0; i < _xmlDocument.ChildNodes.Count; i++)
                {
                    //check to see if it is the root element
                    if (_xmlDocument.ChildNodes[i].Name == "visited_links_list")
                    {
                        //assign the root node
                        rootNode = xDoc.ChildNodes[i];
                        break;
                    }
                }
                //Loop through each of the child nodes of the root node
                for (int j = 0; j < rootNode.ChildNodes.Count; j++)
                {
                    //check for the item tag
                    if (rootNode.ChildNodes[j].Name == "item")
                    {
                        //assign the item node
                        XmlNode itemNode = rootNode.ChildNodes[j];
                        //loop through each if the item tag's elements
                        foreach (XmlNode subNode in rootNode.ChildNodes[j].ChildNodes)
                        {
                            //check for the url tag
                            if (subNode.Name == "url")
                            {
                                //add the url string to the list
                                urlList.Add(subNode.InnerText);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
            //return the list
            return urlList;
        }
