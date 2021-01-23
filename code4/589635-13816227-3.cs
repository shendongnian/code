    protected void Page_Load(object sender, EventArgs e) {
         if (Session["username"] != null) {
              string strSQLconnection = "Data Source=dbServer;Initial Catalog=testDB;Integrated Security=True";
              SqlConnection conn = new SqlConnection(strSQLconnection);
              conn.Open();
              SqlCommand command = new SqlCommand("select * from table1 where username =" + (string)(Session["username"], sqlConnection);
              SqlDataReader reader = sqlCommand.ExecuteReader();
              GridView1.DataSource = reader;
              GridView1.DataBind();
         }
    }
