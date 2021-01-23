    void DeleteButton_Command(Object sender, CommandEventArgs e) 
    {
        if(e.CommandName == "Delete")
        {
            LinkButton btnDelete = (LinkButton)sender;
            var item = (FormViewItem)btnDelete.NamingContainer;
            Label LblUserName = (Label)item.FindControl("LblUserName");
            String userName = LblUserName.Text;
        }
    }
