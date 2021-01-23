        class Mail
        {
            private static string mailAddress = "{you email address}";
            private static string host = "{your host server}";
            private static string userName = "{your user name}";
            private static string password = "{your password}";
            private static string userTo = "{to address}";
            private static void SendEmail(string subject, string message)
            {
                //Generate Message 
                var mailMessage = new MimeMailMessage();
                mailMessage.From = new MimeMailAddress(mailAddress);
                mailMessage.To.Add(userTo);
                mailMessage.Subject = subject;
                mailMessage.Body = message;
                //Create Smtp Client
                var mailer = new MimeMailer(host, 465);
                mailer.User = userName;
                mailer.Password = password;
                mailer.SslType = SslMode.Ssl;
                mailer.AuthenticationMode = AuthenticationType.Base64;
                //Set a delegate function for call back
                mailer.SendCompleted += compEvent;
                mailer.SendMailAsync(mailMessage);
            }
            //Call back function
            private static void compEvent(object sender, AsyncCompletedEventArgs e)
            {
                if (e.UserState != null)
                    Console.Out.WriteLine(e.UserState.ToString());
                Console.Out.WriteLine("is it canceled? " + e.Cancelled);
                if (e.Error != null)
                    Console.Out.WriteLine("Error : " + e.Error.Message);
            }
        }
