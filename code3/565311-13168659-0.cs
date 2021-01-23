                IList<Attachment> iList;
                string htmlBody = "", textBody = "";
                MailMessage msg = new MailMessage();
                msg.Load(cellBody.Value.ToString(), false); // cellBody.Value.ToString() is raw message
                
                textBody = msg.Body;
                
                iList = msg.Attachments as IList<Attachment>;
                if (iList.Count > 0)
                {
                    textBody = iList[0].Body;
                    htmlBody = iList[1].Body;
                    webBrowser1.DocumentText = htmlBody;
                }
                else
                {
                    webBrowser1.DocumentText = textBody;
                }
                textBox1.Text = cellBody.Value.ToString();
