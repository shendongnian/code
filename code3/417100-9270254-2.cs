    protected void Button1_Click(object sender, EventArgs e)
            {
                if (FileUpload1.HasFile) ;
                {
                    var fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    try
                    {
                        string strExtension = Path.GetExtension(fileName);
                        if (strExtension != ".docx" || strExtension != ".doc" || strExtension != ".pdf") ;
                        {
                            return;
                        }
    
                        MailMessage myMessage = new MailMessage();
                        myMessage.To.Add(new MailAddress("OtherPersonsEmail@email.xyz"));
                        myMessage.From = new MailAddress("YourEmailAddress@gmail.com");
                        myMessage.Subject = "Test";
                        myMessage.Body = "asd asd as d";
                        myMessage.IsBodyHtml = true;
                        myMessage.Attachments.Add(new Attachment(FileUpload1.PostedFile.InputStream, fileName));
    
    
                        SmtpClient mySmtp = new SmtpClient();
                        mySmtp.Host = "smtp.gmail.com";
                        mySmtp.Credentials = new System.Net.NetworkCredential("YourEmailAddress@gmail.com", "YourPassword");
                        mySmtp.EnableSsl = true;
                        mySmtp.Send(myMessage);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
