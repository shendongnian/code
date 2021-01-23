    protected ovoid Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        Session["mloginAttempts"] = 0;
        Session["maxLoginAttempt"] = 8;
      }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      int mLoginAttempt = Convert.ToInt32(Session["mloginAttempts"]);
      int maxLoginAttempt = Convert.ToInt32(Session["maxLoginAttempt"]);
    
      if(loginAttempts < maxLoginAttempt & txtPassword.Text != "Test")
      {
        if (loginAttempts == 3)
        {
          Session["mloginAttempts"] = Convert.ToInt32(Session["mloginAttempts"]) + 1;
          ltrStatusMsg.Text = "Lock Warning";
        }
        Session["mloginAttempts"] = Convert.ToInt32(Session["mloginAttempts"]) + 1;
      }
      else
      {
        ltrStatusMsg.Text = "Account Locked";
      } 
    }
