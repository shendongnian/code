     FileInfo objFileInfo = new FileInfo(Assembly.GetExecutingAssembly().Location + ".config");
                XmlDocument objXmlDoc = new XmlDocument();
                objXmlDoc.Load(objFileInfo.FullName);
                XmlElement objElement = objXmlDoc.DocumentElement;
                XmlNode objAppSettingNode = objElement.SelectSingleNode("appSettings");
                foreach (XmlNode appSetting in objAppSettingNode)
                {
                    if (appSetting.Name.Equals("add"))
                    {
                        appSetting.Attributes["value"].Value = txtEmailAddress.Text.Trim();
                    }
                }
                XmlNode objMailSettingNode = objXmlDoc.DocumentElement.SelectSingleNode("system.net/mailSettings");
                if (objMailSettingNode != null)
                {
                    foreach (XmlNode childNode in objMailSettingNode)
                    {
                        if (childNode.Name.ToLower().Equals("smtp"))
                        {
                            childNode.Attributes["from"].Value = txtEmailAddress.Text.Trim();
                            foreach (XmlNode networkNode in childNode)
                            {
                                if (networkNode.Name.ToLower().Equals("network"))
                                {
                                    networkNode.Attributes["host"].Value = txtSmtp.Text.Trim();
                                    networkNode.Attributes["userName"].Value = txtEmailAddress.Text.Split('@')[0].Trim();
                                    networkNode.Attributes["password"].Value = txtPassword.Text.Trim();
                                    networkNode.Attributes["port"].Value = txtPort.Text.Trim();
                                }
                            }
                        }
                    }
                }
                objXmlDoc.Save(objFileInfo.FullName);
                lblErrormsg.Text = string.Empty;
                this.Close();
