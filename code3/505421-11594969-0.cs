    protected void Button1_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Anzeigen")
            {
              //Here I need a Session and the Informations about the Selected User in the Line
                Label lb = (Label) myListView.Items(1).FindControl("Label2"); // give the right index, Label2 contains the email so give its ID but index should be correct
                string email = lb.Text;
                Response.Redirect("Benutzer.aspx");
            }
    }
