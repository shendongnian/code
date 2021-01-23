       LinkButton lnkButton = new LinkButton();
       lnkButton.ID = "lnkdynamicbutton"; 
       lnkButton.Text = "Apply for this job";
       lnkButton.Click += new System.EventHandler(lnkButton_Click);
    
    protected void lnkButton_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "<script>alert('You Clicked me!!!')</script>");
    }
