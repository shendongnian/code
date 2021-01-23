            string toAddress = "testemail@gmail.com;test2@testing.com;";
            Regex rgx = new Regex(@"^[_a-z0-9-]+(\.[_a-z0-9-]+)*(\+[a-z0-9-]+)?@[a-z0-9-]+(\.[a-z0-9-]+)*$");
            List<string> emailArray = new List<string>();
            if(toAddress != null && toAddress != "")
            {
                if (toAddress.IndexOf(";") != -1)
                {
                    emailArray = toAddress.Replace(" ","").Split(';').ToList();
                }
                else
                {
                    emailArray.Add(toAddress);
                }
                foreach (string email in emailArray)
                {
                    if (rgx.IsMatch(email ?? ""))
                    {
                        SendEmail(email, subject, body);
                    }
                }
            }
