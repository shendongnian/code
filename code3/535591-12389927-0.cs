    protected void Button3_Click(object sender, EventArgs e)
    {
         var memUser = Membership.GetUser(TextBox3.Text) //Fetch the user by user Id
         memUser.Email = TextBox2.Text // Assign the new email address
         Membership.UpdateUser(memUser) // update the user record.
    }
