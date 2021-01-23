    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
          localhost.UserRegistration m = new localhost.UserRegistration();
          int user = m.ID(Session["Username"].ToString());
          DataSet ds = m.GetUserInfo(user);
          if (ds.Tables.Count > 0)
          {
              TextBox1.Text = ds.Tables[0].Rows[0]["emailAddress"].ToString();
              TextBox2.Text = ds.Tables[0].Rows[0]["password"].ToString();
          }
      }
    }
