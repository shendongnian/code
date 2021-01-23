     protected void Page_Load(object sender, EventArgs e)
        {
           DataTable dt = new DataTable("Test");
            dt.Columns.Add("Column", typeof(string));
          
            // If I uncomment the line it works!
            // dt.Rows.Add("row 1");
    
           dt.LoadDataRow(new string[1],true);
            dtvTest.DataSource = dt;
            
            dtvTest.DataBind();
           
        }
