    protected void Page_Load(object sender, EventArgs e)
    {
          if(!Page.IsPostBack)
          {   
              SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings    ["vinkpConnectionString"].ConnectionString);
              conn.Open();
              SqlCommand comm = new SqlCommand("select EmployeeID,FirstName,LastName,Title,Country from employeeTable  ", conn);
              comm.ExecuteReader();
              conn.Close();
              SqlDataAdapter da = new SqlDataAdapter(comm);
              DataTable dt = new DataTable();
              da.Fill(dt);
              GridView1.DataSource = dt;
              GridView1.DataBind();
          }
    }
