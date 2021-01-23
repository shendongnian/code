        /// <summary>
        /// Logs the user out of their forms authentication.
        /// </summary>
        public void SignOut()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
