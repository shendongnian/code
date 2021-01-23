        private static bool result;
        private static LoginDialog loginDialog;
        public static bool ShowLoginDialog(Timer timer)
        {
            timer.Stop();
            
            result = false; // Success
            
            loginDialog = new LoginDialog();
            loginDialog.ShowDialog();
            
            return result;
        }  
