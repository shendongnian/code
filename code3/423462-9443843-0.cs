        private void VerifyAccount()
        {
            if (!ValidateCredentials(txtUser.Text, txtPassword.Text))
            {
                MessageBox.Show("Invalid user name or password");
            }
        }
        private bool ValidateCredentials(string userName, string password)
        {
            string existingPassword = GetUserPassword(userName);
            if (existingPassword == null)
                return false;
            var hasher = new Hasher { SaltSize = 16 };
            bool passwordsMatch = hasher.CompareStringToHash(password, existingPassword);
            return passwordsMatch;
        }
        private string GetUserPassword(string userName)
        {
            DataClasses1DataContext dataContext = new DataClasses1DataContext();
            var password = (from user in dataContext.Accounts
                            where user.accnt_User == userName
                            select user.accnt_Pass).FirstOrDefault();
            return password;
        }
