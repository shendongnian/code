    string x,y;
     public Welcome(String usr, String pword)
    {
        InitializeComponent();
    x = usr; y = pword;
    }
    
        private void Welcome_Load(object sender, EventArgs e)
            {
              query = "SELECT * FROM  Users WHERE UserName='"+ x +"'AND Password='"+y+"'";
              cmd.SelectCommand =new SqlCommand(query ,con);
            
        
                ds.Clear();
                cmd.Fill(ds);
               userTable.DataSource = ds.Tables[0];
        txtFristName.DataBindings.Add(new Binding("Text", userTable, "FirstName"));
        txtLastName.DataBindings.Add(new Binding("Text", userTable, "LastName"));
        txtAddress.DataBindings.Add(new Binding("Text", userTable, "Address"));
        txtTelephone.DataBindings.Add(new Binding("Text", userTable, "Telephone"));
        txtEmail.DataBindings.Add(new Binding("Text", userTable, "Email"));
        txtFax.DataBindings.Add(new Binding("Text", userTable, "Fax"));
        txtSection.DataBindings.Add(new Binding("Text", userTable, "Section"));
        txtPosition.DataBindings.Add(new Binding("Text", userTable, "Position"));
        }
