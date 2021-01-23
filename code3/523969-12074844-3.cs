        private User user;
        FormUsersUpdate _frmusrUpdate;
       
        public Form1()
        {
            InitializeComponent();
            this.user = new User { name = "Test" };
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            _frmusrUpdate = new FormUsersUpdate(this.user);
            _frmusrUpdate.UsrChanged += new FormUsersUpdate.UserChangedEventHandler(_frmusrUpdate_UsrChanged);
            _frmusrUpdate.Show();
        }
        void _frmusrUpdate_UsrChanged(object sender, EventArgs e)
        {
            MessageBox.Show("User Details Changed");
        }
    }
