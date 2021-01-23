      public void Send(string from, string to, string Message, string subject, string host, int port, string password)
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress(from);
            email.Subject = subject;
            email.Body = Message;
            SmtpClient smtp = new SmtpClient(host, port);
            smtp.UseDefaultCredentials = false;
            NetworkCredential nc = new NetworkCredential(txtFrom.Text.Trim(), password);
            smtp.Credentials = nc;
            smtp.EnableSsl = true;
            email.IsBodyHtml = true;
            email.To.Add(to);
            string fileName = "";
            if (FileUpload1.PostedFile != null)
            {
                HttpPostedFile attchment = FileUpload1.PostedFile;
                int FileLength = attchment.ContentLength;
                if (FileLength > 0)
                {
                    fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.PostedFile.SaveAs(Path.Combine(Server.MapPath("~/EmailAttachment"), fileName));
                    Attachment attachment = new Attachment(Path.Combine(Server.MapPath("~/EmailAttachment"), fileName));
                    email.Attachments.Add(attachment);
                }               
            }
            smtp.Send(email);
        }
