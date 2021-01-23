    public partial class PasswordUserControl : UserControl
    {
        public SecureString Password
        {
            get { return (SecureString) GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(SecureString), typeof(UserCredentialsInputControl),
                new PropertyMetadata(default(SecureString)));
        public PasswordUserControl()
        {
            InitializeComponent();
            // Update DependencyProperty whenever the password changes
            PasswordBox.PasswordChanged += (sender, args) => {
                Password = ((PasswordBox) sender).SecurePassword;
            };
        }
    }
