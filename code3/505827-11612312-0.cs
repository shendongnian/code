    protected void Button1_Command(object sender, CommandEventArgs e)
            {
                if (e.CommandName == "Select")
                {
                   int index = Convert.ToInt32(e.CommandArgument);
                   
                    Label lb = (Label)myListView.Items[index].FindControl("Label2");
    
                    string email = lb.Text;
    
                    Session["email"] = email;
    
                    Response.Redirect("Benutzer.aspx");
    
                }
    
            }
