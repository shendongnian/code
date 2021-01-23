    MailMessage mail = new MailMessage();
                mail.To.Add("" + to + "");
                mail.From = new MailAddress("" + from + "");
                mail.Subject = "Email using Gmail";
                string Body = "Hi, this mail is to test sending mail" +
                              "";
                mail.Body = Body;
                mail.IsBodyHtml = true;
                Attachment at = new Attachment(Server.MapPath("~/ExcelFile/TestCSV.csv"));
                mail.Attachments.Add(at);
                mail.Priority = MailPriority.High;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential(""+ username +"", ""+ password +"");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Send(mail);
