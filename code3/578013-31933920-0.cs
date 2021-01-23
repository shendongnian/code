               MailMessage mail = new MailMessage();
               //SmtpClient SmtpServer = new SmtpClient("smtp.google.com");
              SmtpClient SmtpServer = new SmtpClient(sServer);
              // SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
               mail.From = new MailAddress(sFromEmailId);
               mail.To.Add(sToEmailId);
               mail.Subject = sSubject;
               mail.Body = sMessage;
               mail.IsBodyHtml = true;             
               HttpFileCollection hfc = Request.Files;
               for (int i = 0; i < hfc.Count; i++)
               {
                   HttpPostedFile hpf = hfc[i];
                   if (hpf.ContentLength > 0)
                   {
                       mail.Attachments.Add(new Attachment(fupload.PostedFile.InputStream, hpf.FileName));
                   }
               }
               SmtpServer.Port = 587;
               //SmtpServer.Host = "smtp.gmail.com";
               SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
               SmtpServer.UseDefaultCredentials = false;
               SmtpServer.Credentials = new System.Net.NetworkCredential(sFromEmailId, sPassword);
               SmtpServer.EnableSsl = true;
               SmtpServer.Send(mail);                
               ClientScript.RegisterStartupScript(this.GetType(), "Alert", "dim('Mail Sent Successfully..!');", true);
               mail.Dispose();
           }
           catch (Exception ex)
           {                
               ClientScript.RegisterStartupScript(this.GetType(), "Alert", "dim('Error in Sending Mail..!');", true);
           }   
