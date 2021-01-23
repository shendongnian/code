            XmlDocument doc = new XmlDocument();
            doc.LoadXml(load your xml document or string here);
            XmlNodeList xnList = doc.SelectNodes("Response0/Data/AcceptReport");
            foreach (XmlNode xn in xnList)
                                {
                                    string status = xn["StatusTest"].InnerText;
                                    string messageID = xn["MessageID"].InnerText;
                                    string recipient = xn["Recipient"].InnerText;
                                }
            string finalString = string.Format("{0} Message ID: {1} Recipient {2}", status, messageID, recipient);
