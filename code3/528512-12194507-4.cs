        protected void Button1_Click(object sender, EventArgs e)
        {
            NameLabel.Text = UserNoTextBox.Text;
            var user = SomeType.GetUser(UserNoTextBox.Text);
            // do something with user
        }
        ...
        public User GetUser(string userNumber) {
           ... your DB code here
        }
