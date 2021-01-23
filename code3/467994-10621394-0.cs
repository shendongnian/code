    public void Page_Load(object sender, EventArgs args)
    {
      u = Membership.GetUser(User.Identity.Name);
    
      if (!IsPostBack)
      {
        EmailTextBox.Text = u.Email; 
      }
    }
