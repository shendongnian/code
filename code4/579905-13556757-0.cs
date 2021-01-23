    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.HighlightNavItem("Customers");
        
        if(!IsPostBack)
        {
			int CustomerID = Int32.Parse(Request.QueryString["ID"]);
			//Declare the connection object
			SqlConnection Conn = new SqlConnection();
			Conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
			//Connect to the db
			Conn.Open();
			//Define query
			string sql = "SELECT * FROM Customer where CustomerID=@CustomerID";
			//Declare the Command
			SqlCommand cmd = new SqlCommand(sql, Conn);
			//Add the parameters needed for the SQL query
			cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
			//Declare the DataReader
			SqlDataReader dr = null;
			//Fill the DataReader
			dr = cmd.ExecuteReader();
			//Get the data
			if (dr.Read() == false)
				{
					//No Records
					dr.Close();
					Conn.Close();
					return;
				}
			txtFirstName.Text = dr["FirstName"].ToString();
			txtLastName.Text = dr["LastName"].ToString();
			txtEmail1.Text = dr["Email"].ToString();
			txtEmail2.Text = dr["Email"].ToString();
			txtPassword1.Text = dr["Password"].ToString();
			txtPassword2.Text = dr["Password"].ToString();
			txtAddress1.Text = dr["Address1"].ToString();
			txtAddress2.Text = dr["Address2"].ToString();
			txtCity.Text = dr["City"].ToString();
			txtState.Text = dr["State"].ToString();
			txtZip.Text = dr["Zip"].ToString();
			txtPhone.Text = dr["Phone"].ToString();
			txtFax.Text = dr["Fax"].ToString();
			dr.Close();
			Conn.Close();
		}
    }
