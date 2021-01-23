      protected void btnSubmit_Click(object sender, EventArgs e)
            {
                if (fileUpload1.HasFile) ;
                {
                    var fileName = Path.GetFileName(fileUpload1.PostedFile.FileName);
                    try
                    {
                        string strExtension = Path.GetExtension(fileName);
                        if (strExtension != ".docx" || strExtension != ".doc" || strExtension != ".pdf") ;
                        {
                            lblFile.ForeColor = Color.Red;
                            lblFile.Text = "You can attach .doc,.docx and pdf files only";
                            lblStatus.ForeColor = Color.Red;
                            lblStatus.Text = "There was an error occured while sending your email. Please try again later.";
                            return;
                        }
                        
                        MailMessage myMessage = new MailMessage();
                        myMessage.From = new MailAddress(txtEmail.Text);
                        myMessage.To.Add(new MailAddress("EMAIL@yahoo.com"));
                        myMessage.Subject = txtSubject.Text;
                        myMessage.Body = "<html><body><br/><b>Sender Name:</b>&nbsp;" + txtName.Text.ToString() + "<br/><br/><b>Email:</b>&nbsp;" + txtEmail.Text.ToString() +
                                        "<br/><br/><b>Contact Number:</b>&nbsp;" + txtContact.Text.ToString() + "<br/><br/><b>Subject</b>&nbsp;" + txtSubject.Text.ToString() +
                                        "<br/><br/><b>CV Summary:</b><br/><br/>" + txtSummary.Text.ToString() + "</body></html>";
                        myMessage.IsBodyHtml = true;
                        myMessage.Attachments.Add(new Attachment(fileUpload1.PostedFile.InputStream, fileName));
    
    
                        SmtpClient mySmtp = new SmtpClient();
                        mySmtp.Host = "smtp.gmail.com";
                        mySmtp.Credentials = new System.Net.NetworkCredential("EMAIL@gmail.com", "PASSWORD");
                        mySmtp.EnableSsl = true;
                        mySmtp.Send(myMessage);
    
                        lblStatus.ForeColor = Color.Green;
                        lblStatus.Text = "Email successfully sent! We will contact you as soon as you have been shortlisted for the position you are applying for.<br/> Thank You. You can close this window now. ";
                        txtName.Text = "";
                        txtEmail.Text = "";
                        txtSubject.Text = "";
                        txtSummary.Text = "";
                        txtContact.Text = "";
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
    
            }
