    protected void Page_Load(object sender, EventArgs e)
    {
      var connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFileName=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True";
      using(var connection = InitializeDatabase(connectionString))
      {
        var admin = GetAdminsByUsername(connection, username).FirstOrDefault();
 
        if(admin == null)
        {
          // No admin was found, do something here.
          return;
        }
        
        var newItem = new ListItem();
        newItem.Text = admin.Department.
        newItem.Value = admin.Username;
        // Keep your controls named consistently, don't use shorthands
        // since you already have IntelliSense to auto-complete them for you
        usernameLabel.Text = admin.Username;
        departmentLabel.Text = admin.Department;
      }
