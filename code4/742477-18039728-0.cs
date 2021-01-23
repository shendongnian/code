           private void getAccount()
            {
                string user = "";
                string pass = "";
                string[] user_pass = new string[0];
    
                var accts = System.IO.File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Accts.txt");
                
    
                foreach(var acct in accts)
                {
                    user_pass = acct.Split(':');
                }
    
    
                //Add iteration for multiple lines
                if (user_pass.Length > 0)
                {
                    MessageBox.Show("Username is " + user_pass[0] + ". \n\nPassword is " + user_pass[1] + ".");
                }
                else
                {
                    MessageBox.Show("Chaos: Dogs and Cats Living Together!");
                }
    
            }
        }
    }
