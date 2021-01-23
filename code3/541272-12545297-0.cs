            //...
            foreach (string indirizzo in indirizzi)
            {
                string htmlBody = "someHTML";
                MailMessage mail = new MailMessage 
                {
                    From = new MailAddress("address.it"),
                    Subject = "oggetto",
                    IsBodyHtml = true,
                    Body = htmlBody,
                };
                mail.To.Clear();
                mail.To.Add(indirizzo);
                SmtpServer.Send(mail);
            }
