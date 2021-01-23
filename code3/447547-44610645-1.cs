     		        XmlDocument xDoc = new XmlDocument();
                    string Bingo = "Identification code";
                    xDoc.Load(pathFile);
                    XmlNodeList idList = xDoc.GetElementsByTagName("id");
                    XmlNodeList statusList = xDoc.GetElementsByTagName("Status");         
                    for (int i = 0; i < idList.Count; i++)
                    {
                        StatusNode = "<Status>fail</Status>";
                        XmlDocumentFragment fragment = xDoc.CreateDocumentFragment();
                        fragment.InnerXml = StatusNode;
                        statusList[i].InnerXml = "";
                        statusList[i].AppendChild(fragment);
                        if (statusList[i].InnerText == Bingo)
                        {
                        StatusNode = "<Status>Succes!</Status>";
                        fragment.InnerXml = Status;
                        statusList[i].InnerXml = "";
                        statusList[i].AppendChild(fragment);
                       
                        }
                       
                    }
                    xDoc.Save(pathFile);
