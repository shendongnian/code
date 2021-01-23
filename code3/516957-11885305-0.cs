                void method1(){
                   using (var Dest = new DataStream(true))
                   {
                       MailMessage m = Method2(Dest);
                       .....
                       m.Send();
                   }
                }
                MailMessage Method2(Stream Dest){
                    // code that reads info into the stream
                    // Go back to the start of the stream
                    Dest.Position = 0;
                    // Create attachment from the stream
                    Attachment mailattachement = new Attachment(Dest, contentType);
                    //Create our return value
                    var message = new MailMessage();
                    message.To.Add(UserInfo.UserDetail.Email);
                    message.Subject = "P&L Data View - " + DateTime.Now.ToString();
                    message.Attachments.Add(mailattachement);
                    return message;
               }
