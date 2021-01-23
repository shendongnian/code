    using( OpenPop.Pop3.Pop3Client client = new Pop3Client())
            {
                client.Connect("in.mail.Your.Mailserver.com", 110, false);
                client.Authenticate("usernamePop3", "passwordPop3", AuthenticationMethod.UsernameAndPassword);
                if (client.Connected)
                {
                    int messageCount = client.GetMessageCount();
                    List<Message> allMessages = new List<Message>(messageCount);
                    for (int i = messageCount; i > 0; i--)
                    {
                        allMessages.Add(client.GetMessage(i));
                    }
                    foreach (Message msg in allMessages)
                    {
                        var att = msg.FindAllAttachments();
                        foreach (var ado in att)
                        {
                            ado.Save(new System.IO.FileInfo(System.IO.Path.Combine("c:\\xlsx", ado.FileName)));
                        }
                    }
                }
               }
