    protected void Button1_Click(object sender, EventArgs e)
    {
        UserController uc = new UserController();
        User u = UserController.GetUser(Convert.ToInt32(UserNoTextBox.Text);
        NameLabel.Text = u.UserName;
    }
