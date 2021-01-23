            Pop3Client client = new Pop3Client();
            try
            {            
                client.Connect("MailServerName", Port_Number, UseSSL); //UseSSL true or false
                client.Authenticate("UserID", "password");
        
                int messageCount = client.GetMessageCount();
                List<Message> Messages = new List<Message>(messageCount);
                for (int i = 0;i < messageCount; i++)
                {
                    Message getMessage = client.GetMessage(i + 1);
                    Messages.Add(getMessage);
                }
             
                foreach (Message msg in Messages)
                {
                    foreach (var attachment in msg.FindAllAttachments())
                    {
                        string filePath = Path.Combine(@"C:\Attachment", attachment.FileName);
                        if(attachment.FileName.Equals("blabla.pdf"))
                        {
                            FileStream Stream = new FileStream(filePath, FileMode.Create);
                            BinaryWriter BinaryStream = new BinaryWriter(Stream);
                            BinaryStream.Write(attachment.Body);
                            BinaryStream.Close();
                         }
                     }
                 }
                              
            }
            catch (Exception ex)
            {
                Console.WriteLine("", ex.Message);
             
            }
            finally
            {
                if (client.Connected)
                    client.Dispose();
            }
