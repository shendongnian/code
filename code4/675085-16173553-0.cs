    public class LoginViewModel
    {
        public event EventHandler OnRequestClose;
    
        private void Login()
        {
            // Login logic here
            OnRequestClose(this, new EventArgs());
        }
    }
