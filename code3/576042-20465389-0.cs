                //You can access the network credentials in the following way.
                //Read the SmtpClient section from the config file    
                var smtp = new System.Net.Mail.SmtpClient();
                //Cast the newtwork credentials in to the NetworkCredential class and use it .
                var credential = (System.Net.NetworkCredential)smtp.Credentials;
                string strHost = smtp.Host;
                int port = smtp.Port;
                string strUserName = credential.UserName;
                string strFromPass = credential.Password;
