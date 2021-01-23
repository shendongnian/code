    var SMTP = new SmtpClient
            {
                Host = txtBxSenderHost.Text,
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(strSenderAddress, strSenderPassword)
            };
            Thread T1 = new Thread(delegate()
            {
                using (var message = new MailMessage(senderAdrress, toAddress)
                {
                    Subject = strSubject,
                    Body = strBody
                })
                {
                    {
                        SMTP.Send(message);
                    }
                }
            });
            T1.Start();
