        protected void Button1_Click(object sender, EventArgs e)
                {
                    if (FileUpload1.HasFile) ;
                    {
                        var fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        try
                        {
                            string strExtension = Path.GetExtension(fileName);
                            if (strExtension != ".docx" || strExtension != ".doc" || strExtension != ".pdf")
                            {
                                lblFile.ForeColor = Color.Red;
                                lblFile.Text = "You can attach .doc,.docx and pdf files only";
                                lblStatus.ForeColor = Color.Red;
                                lblStatus.Text = "There was an error occured while sending your email. Please try again later.";
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
                            lblStatus.ForeColor = Color.Red;
                            lblStatus.Text = ex.Message;
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
