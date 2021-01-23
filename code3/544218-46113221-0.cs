    if (ModelState.IsValid)
            {
                try{
                string from = "abcd@gmail.com";
                using (MailMessage mail = new MailMessage(from, obj.Idemail))
                {
                    mail.Subject = "Admin";
                    mail.Body = "Registration successful!";
                    mail.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential networkCredential = new NetworkCredential(from, "pswd");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    smtp.Host = "localhost";
                    smtp.Send(mail); 
                    ViewBag.Message = "Password Sent through mail. Please chack password in your account and signup.";
                }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error occur for sending data";
                }
            }
           
            else
            {
                return Json("Invalid Information!", JsonRequestBehavior.AllowGet);
            }
            
