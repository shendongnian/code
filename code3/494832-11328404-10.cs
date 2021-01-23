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
    			command.CommandType = CommandType.Text;
    			command.CommandText = "SELECT * FROM Table WHERE Category = @Category AND SubCategory = @SubCategory";
    			
    			command.Parameters.Add(new SqlParameter() { Type = SqlDbType.String, Name = "@Category", Value = s });
    			command.Parameters.Add(new SqlParameter() { Type = SqlDbType.String, Name = "@SubCategory", Value = s1 });
    			
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
