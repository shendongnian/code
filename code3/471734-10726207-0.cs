    SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
    SqlCommand GridDataSource= new SqlCommand();
    SqlDataReader reader;
    
    GridDataSource.CommandText = "SELECT * FROM AUDITS";
    GridDataSource.CommandType = CommandType.Text;
    GridDataSource.Connection = sqlConnection1;
    
    sqlConnection1.Open();
    
    GridView1.DataSource = GridDataSource.ExecuteReader();
    GridView1.DataBind();
