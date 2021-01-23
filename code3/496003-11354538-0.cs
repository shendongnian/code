    protected override void OnPreRender()
        {
            if (Message != string.Empty)
            {
    
                lblMessage.Text = Message;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "showMsg('" + Status + "');", true);
            }
    
        }
