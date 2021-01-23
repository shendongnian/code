    protected void lnkClickButton_Click(object sender, EventArgs e)
    {
        if (Session["clickcount"] == null)
        {
                Session["clickcount"] = 1;
        }
        else
        {
               Session["clickscount"] = (int)Session["clickscount"] + 1;
        }
        Label myLabel = ((Label)this.FindControl("myLabel"));
        if (myLabel != null)
        {
            myLabel.Text = "Session: " + Session["clickcount"] + "; 
        }
    }
