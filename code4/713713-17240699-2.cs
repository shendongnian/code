    protected void Page_Load(object sender, EventArgs e)
    {
    	SqlConnection conn = new SqlConnection(<the info>);
    	SqlCommand cmd = new SqlCommand("SELECT * FROM fb_results", conn);
    	DataTable dt = new DataTable();
    	SqlDataAdapter da = new SqlDataAdapter(cmd);
    	da.Fill(dt);
    	
    	DataTable newTable = createDataTableTemplate();
    	foreach (DataRow dr in dt.Rows) {
    		DataRow newRow = newTable.NewRoW();
    		
    		newRow["strFirst"] = SomeOperation((String) dr["Column 1"]);
    		newRow["strLast"] = SomeOtherOperation((String) dr["Column 2"]);
    		
    		newTable.Rows.Add (newRow);
    	}
    	
    	GridView1.DataSource = newTable;
    	GridView1.DataBind();
    	
    	conn.Close();
    }
    
    private DataTable createDataTableTemplate ()
    {
    	DataTable table = new DataTable("Table Title");
    	
    	DataColumn col1 = new DataColumn("strFirst");
    	col1.DataType = System.Type.GetType("System.String");
    	
    	DataColumn col2 = new DataColumn("strLast");
    	col2.DataType = System.Type.GetType("System.String");
    	
    	table.Columns.Add (col1);
    	table.Columns.Add (col2);
    	
    	return table;
    }
