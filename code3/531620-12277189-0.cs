    protected void userList_SelectedIndexChanging(object sender, ListViewSelectEventArgs e) 
    { 
        userList.SelectedIndex = e.NewSelectedIndex; 
        string uid = userList.DataKeys[e.NewSelectedIndex].Value.ToString(); 
        Label1.Text = "Selected username: " + uid; 
        BindGenerics(); 
        Session["SelectedUserId"] = uid;
    }
    protectec void edit_Click(Object sender, EventArgs e)
    {
        string uid = Session["SelectedUserId"].ToString();
        // Do whatever with uid
    }
    protectec void delete_Click(Object sender, EventArgs e)
    {
        string uid = Session["SelectedUserId"].ToString();
        // Do whatever with uid
    }
