    protected void Page_Load(object sender, EventArgs e) 
    {
       if (IsPostBack == false)
       {
          string s = Request.QueryString["cat"];
          string s1 = Request.QueryString["sub"];
          
          if(String.IsNullOrEmpty(s) || String.IsNullOrEmpty(s1)) { return; } //Improve Validation and error reporting
          
          using(SqlConnection conn = new SqlConnection("Data Source=ANURAG-PC;Initial Catalog=dbPortal;Persist Security Info=True;User ID=sa;Password=anurag"))
          {
    		using(SqlCommand command = new SqlCommand(conn))
    		{
    			command.CommandType = CommandType.Table;
    			
    			switch(s)
    			{
    				case "Architect":
    					command.CommandText = "SELECT * FROM Architext WHERE Category = SubCategory = @SubCategory";
    					break;
    				case "SomethingElse":
    					command.CommandText = "SELECT * FROM SomethingElse WHERE Category = SubCategory = @SubCategory";
    					break;
    				default:
    					return; //Again, improve error handling
    			}
    	
    			command.Parameters.Add(new SqlParameter() { Type = SqlDbType.String, Name = "@SubCategory, Value = s1 });
    			
    			conn.Open();
    			
    			using(SqlDataReader reader = command.ExecuteReader())
    			{
    				DataTable data = new DataTable("MyData");
    				data.Load(reader);
    				DataGrid1.DataSource = data;
    				DataGrid1.DataBind();
    			}
    			
    		}
          }
       }
    }
