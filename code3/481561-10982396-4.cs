    public void AddUser()
    {
        string username = txtUsername.Text;
        
        // Either update the database with a new user
        User newUser = User(username);
        WhateverDataAccessYoureUsing.Add(User);
        List<User> users = WhateverDataAccessYoureUsing.GetAllUsers();
        lbUsers.DataSource = users;
        lbUsers.DataBind();
        // OTHER OPTION
        //
        // Or if no database directly bind the user to the ListBox
        ListItem li = new ListItem(username);
        lbUsers.Items.Add(li);
    }
    protected void btAdd_Click(object sender, EventArgs e)
    {
         AddUser();
    }
