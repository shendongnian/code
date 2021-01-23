     SqlConnection connection = new SqlConnection();
     connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
     SqlCommand command = new SqlCommand(sqlSelectFindUserByName);
 
     connection.Open();
     command.Connection = connection;
     SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
     GridView1.DataSource = reader;
     GridView1.DataBind();
