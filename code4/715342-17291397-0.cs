         XmlDataDocument xmlReaderDoc = new XmlDataDocument();
                FileStream xmlFileStream = new FileStream(F_ECAS_CONFIG.xlmfile_load_path, FileMode.Open, FileAccess.Read);
                xmlReaderDoc.Load(xmlFileStream);
                System.Xml.XmlElement root = xmlReaderDoc.DocumentElement;
                XmlNodeList messageList = root.GetElementsByTagName("Message");
                foreach (System.Xml.XmlNode message in messageList)
                {
                    XmlNodeList childnodeList = message.ChildNodes;
                    foreach (System.Xml.XmlNode childNode in childnodeList)
                    {
                        if (childNode.InnerText.IndexOf("CAS MESSAGE") != -1)
                        {
                        }
                        else if (childNode.InnerText.IndexOf("casTextLine") != -1)
                        {
                            Cl_Ecas_ADE.textline_path.Add(childNode.InnerText); 
                        }
                        else if (childNode.InnerText.IndexOf("casLevel") != -1)
                        {
                            Cl_Ecas_ADE.cas_level_path.Add(childNode.InnerText);
                        }
                        else if (childNode.InnerText.IndexOf("casAckLine") != -1)
                        {
                            Cl_Ecas_ADE.ack_line_path.Add(childNode.InnerText);
                        }
                    }
                }
