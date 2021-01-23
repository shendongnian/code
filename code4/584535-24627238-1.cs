    System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient(System.Configuration.ConfigurationSettings.AppSettings["smtp"]);        
     
                //code by cv 8july2014
                mailClient.UseDefaultCredentials = false; // <<<you need THIS
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "username";
                NetworkCred.Password = "Pasword";
                mailClient.Credentials = NetworkCred;
             //   mailClient.Host = "my company mail site";//host of your mail account
                mailClient.Port = 2525;
              
                // mailMsg = null;
                //SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["smtp"];
                while (counter < 3)
                {
                    try
                    {
                        mailClient.Send(mailMsg);        
                        Thread.Sleep(2000);
                        counter = 3;
                        mailMsg = null;
                    }
                    catch (Exception ex)
                    {
                        counter = counter + 1;
                        if (counter == 2)
                        {
                            throw ex;
                            counter = 0;
                        }
                    }
                }
