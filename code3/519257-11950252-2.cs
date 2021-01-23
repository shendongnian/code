        public LoginForm()
        {
            InitializeComponent();
            if (DoAuthentication)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
            this.Close();
        }
