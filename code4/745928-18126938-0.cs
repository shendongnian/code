        public InputUserView()
        {
            InitializeComponent();
            this.DataContext = InputUserViewModel.Instance;
            InputUserViewModel.Instance.PasswordBox1 = txtPassword;
            InputUserViewModel.Instance.PasswordBox2 = txtRepeatPassword;
        }
