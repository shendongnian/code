    System.IO.StreamReader sr = new System.IO.StreamReader("test.xml");
    String xmlText = sr.ReadToEnd();
    sr.Close();
    
    List<UserInfo> finalList = readXMLDoc(xmlText);
    if(finalList != null)
    {
        //do something
    }
        private List<UserInfo> readXMLDoc(String fileText)
        {
            //create a list of Strings to hold our user information
            List<UserInfo> userList = new List<UserInfo>();
            try
            {
                //create a XmlDocument Object
                XmlDocument xDoc = new XmlDocument();
                //load the text of the file into the XmlDocument Object
                xDoc.LoadXml(fileText);
                //Create a XmlNode object to hold the root node of the XmlDocument
                XmlNode rootNode = null;
                //get the root element in the xml document
                for (int i = 0; i < xDoc.ChildNodes.Count; i++)
                {
                    //check to see if we hit the root element
                    if (xDoc.ChildNodes[i].Name == "RootElement")
                    {
                        //assign the root node
                        rootNode = xDoc.ChildNodes[i];
                        break;
                    }
                }
                //Loop through each of the child nodes of the root node
                for (int j = 0; j < rootNode.ChildNodes.Count; j++)
                {
                    //check for the UserInformation tag
                    if (rootNode.ChildNodes[j].Name == "UserInformation")
                    {
                        //assign the item node
                        XmlNode userNode = rootNode.ChildNodes[j];
                        //create userInfo object to hold results
                        UserInfo userInfo = new UserInfo();
                        //loop through each if the user tag's elements
                        foreach (XmlNode subNode in userNode.ChildNodes)
                        {
                            //check for the name tag
                            if (subNode.Name == "Name")
                            {
                                userInfo._name = subNode.InnerText;
                            }
                            //check for the age tag
                            if (subNode.Name == "Age")
                            {
                                userInfo._age = subNode.InnerText;
                            }
                            String tagToLookFor = "CallTheMethodThatReturnsTheCorrectTag";
                            //check for the tag
                            if (subNode.Name == tagToLookFor)
                            {
                                foreach (XmlNode elementNode in subNode.ChildNodes)
                                {
                                    //check for the element1 tag
                                    if (elementNode.Name == "Element1")
                                    {
                                        userInfo._element1 = elementNode.InnerText;
                                    }
                                    //check for the element2 tag
                                    if (elementNode.Name == "Element2")
                                    {
                                        userInfo._element2 = elementNode.InnerText;
                                    }
                                    //check for the element3 tag
                                    if (elementNode.Name == "Element3")
                                    {
                                        userInfo._element3 = elementNode.InnerText;
                                    }
                                }
                               
                            }
                        }
                        //add the userInfo to the list
                        userList.Add(userInfo);
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
            //return the list
            return userList;
        }
        
        //struct to hold information
        struct UserInfo
        {
            public String _name;
            public String _age;
            public String _element1;
            public String _element2;
            public String _element3;
        }
