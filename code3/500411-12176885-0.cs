     protected void Page_Load(object sender, EventArgs e)
     {
       string planType=Request.QueryString["type"];
       if (planType == "False")
        {
          rdodomiantype.Items.Remove(rdodomiantype.Items.FindByValue("1"));
        }
     }
