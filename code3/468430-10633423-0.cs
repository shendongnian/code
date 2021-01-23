                    MailMessage message = new MailMessage(new MailAddress(txtSenderMail.Text, txtSenderName.Text), new MailAddress(txtToAdd.Text);
                    message.IsBodyHtml = true;
                    message.Subject = txtSubject.Text;
                    message.Body = txtMail.Text;
                    message.Priority = MailPriority.High;
                    SmtpClient smtp = new SmtpClient(YOUR SMTP ADDRESS, YOUR SMTP PORT);
                    smtp.EnableSsl = false;
                    smtp.UseDefaultCredentials = false; //you can use this line if you have your own SMTP server if not set it **True** (also you can get server address of your internet service company. like mine is: smtp.datak.ir  but it only works on your own computer not Web server. webservers could have SMTP too.) 
                    smtp.Send(message);
