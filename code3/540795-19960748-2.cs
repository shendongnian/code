    //Try To Fetch The Value Like this...
    protected void Search_Emp_Click(object sender, EventArgs e)
    {
		SqlCommand cmd;
		SqlConnection con;
		SqlDataAdapter ad;
		con = new SqlConnection(); //making instance of SqlConnection
		con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; //Invoking Connection String
		con.Open(); //Opening Connection
		
		if (Ddl_Emp_Search.SelectedItem.Text == "Date Of Joining")
		{
			cmd = new SqlCommand("Select Emp_Name,Contact_No,City,Emp_Desig,Place_Code from emp_registration where Emp_Doj=@Emp_Doj",con);
			cmd.Parameters.Add("@Emp_Doj", SqlDbType.NVarChar, 50).Value = TextBox1.Text;
		}
		else if (Ddl_Emp_Search.SelectedItem.Text == "Name")
		{
			cmd = new SqlCommand("Select Emp_Name,Place_Code,Emp_Code,Emp_Desig from emp_registration where Emp_Name=@Emp_Name", con);
			cmd.Parameters.Add("@Emp_Name", SqlDbType.NVarChar, 50).Value = TextBox1.Text;
		}
		else if (Ddl_Emp_Search.SelectedItem.Text == "Employee Code")
		{
			cmd = new SqlCommand("Select Emp_Name,Contact_No,City,Emp_Desig,Place_Code from emp_registration where Emp_Code=@Emp_Code", con);
			cmd.Parameters.Add("@Emp_Code", SqlDbType.NVarChar, 50).Value = TextBox1.Text;
		}
		else if (Ddl_Emp_Search.SelectedItem.Text == "City")
		{
			cmd = new SqlCommand("Select Emp_Name,Contact_No,City,Emp_Desig,Place_Code from emp_registration where City=@City", con);
			cmd.Parameters.Add("@City", SqlDbType.NVarChar, 50).Value = TextBox1.Text;
		}
		else
		{
			Response.Write("There is Something Worng....");
		}
		ad = new SqlDataAdapter(cmd); // Here IS THE PROBLEM WHEN YOU DOES'NT PASS CMD (Command instance) to the Data Adapter then there is a problem of ( Fill: SelectCommand.Connection property has not been initialized)
		DataSet ds = new DataSet();
		ad.Fill(ds);
		GridView1.DataSource = ds;
		GridView1.DataBind();
    }
