    var doc1 = XDocument.Load(appConfigFile1);
    
                    var list1 = from appNode in doc1.Descendants("appSettings").Elements()
                                where appNode.Attribute("key").Value == "UserName"
                                select appNode;
                    var list2 = from appNode in doc1.Descendants("appSettings").Elements()
                                where appNode.Attribute("key").Value == "Password"
                                select appNode;
                    var list3 = from appNode in doc1.Descendants("appSettings").Elements()
                                where appNode.Attribute("key").Value == "DBUserName"
                                select appNode;
                    var list4 = from appNode in doc1.Descendants("appSettings").Elements()
                                where appNode.Attribute("key").Value == "DBPassword"
                                select appNode;
                    // the values of missing elements are null so you can use the "??" operator                                               //hat put something else when you have null
                    var element1 = list1.FirstOrDefault() ?? "your default value";
                    var element2 = list2.FirstOrDefault() ?? "your default value";
                    var element3 = list3.FirstOrDefault() ?? "your default value";
                    var element4 = list4.FirstOrDefault() ?? "your default value";
                    element1.Attribute("value").SetValue(txtbox1);
                    element2.Attribute("value").SetValue(txtbox2);
                    element3.Attribute("value").SetValue(txtbox3);
                    element4.Attribute("value").SetValue(txtbox4);
                    doc1.Save(appConfigFile1);
