            for (int line = 0; line < acct.Length; line++)
            {
                if (acct[line].Contains(":"))
                {
                    string[] parts = acct[line].Split(':');
                    user = parts[0];
                    pass = parts[1];
                    MessageBox.Show("Username is " + user + ". \n\nPassword is " + pass + ".");
                }
            }
