      protected void Page_Load(object sender, EventArgs e)
        {
         
            SqlConnection sql = new SqlConnection( ConfigurationManager.ConnectionStrings["yourConnectionName"].ConnectionString);
            sql.Open();
            SqlCommand command = new SqlCommand("Select * from userinfo where uloginid=@user", sql);
            command.Parameters.AddWithValue("@user", User.Identity.Name.ToString());
            SetDropDownList(command);
            DropDownList1.SelectedIndex = 0;
            sql.Close();
        }
        protected void SetDropDownList(SqlCommand command)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "uFirstName";
            DropDownList1.DataBind();
        }
