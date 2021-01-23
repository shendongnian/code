    OpenPOP.POP3.POPClient client = new POPClient("pop.yourserver.co.uk", 110, "your@email.co.uk", "password_goes_here", AuthenticationMethod.USERPASS); 
    if (client.Connected) {
    int msgCount = client.GetMessageCount();
    /* Cycle through messages */
    for (int x = 0; x < msgCount; x++)
        {
            OpenPOP.MIMEParser.Message msg = client.GetMessage(x, false);
            if (msg != null) {
                for (int y = 0; y < msg.AttachmentCount; y++)
                {
                    Attachment attachment = (Attachment)msg.Attachments[y];
                     
                    if (string.Compare(attachment.ContentType, "text/xml") == 0)
                    {
                        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                        string xml = attachment.DecodeAsText();
                        doc.LoadXml(xml);
                        doc.Save(@"C:\POP3Temp\test.xml");
                    }
                }
            }
        }
    }
