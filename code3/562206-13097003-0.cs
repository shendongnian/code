        public bool CreateAccount(String username, String password)
        {
            createAccounts();
            try
            {
                sw = File.AppendText(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (!usernameExists(username))
            {
                sw.WriteLine(username + "," + password + "\n");
                sw.Close();
                sw = null;
                return true;
            }
            else
            {
                sw.Close();
                sw = null;
                return false;
            }
        }
