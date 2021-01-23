    private void btnAddUser_Click(object sender, EventArgs e)
    {
        using (var db = new DocMgmtDataContext())
        {
             User user = new User()
             {
                    FullName = NewUserName.Text //fix
             };
             db.Users.InsertOnSubmit(user);
             db.SubmitChanges();
        }
    }
