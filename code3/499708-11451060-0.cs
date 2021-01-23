    public partial class LoginForm : Form
    {
        public event EventHandler LoginExpired;
    
        public LoginForm()
        {
            InitializeComponent();
            timer.Start();
        }
    
        private void timer_Tick(object sender, EventArgs e)
        {
            OnLoginExpired();
        }
    
        protected virtual void OnLoginExpired()
        {
            if (Visible)
                return; // if this form visible, then user didn't authenticate yet
    
            if (LoginExpired != null)
                LoginExpired(this, EventArgs.Empty);
        }        
    }
