        SqlConnection sqlCn = new SqlConnection( ConfigurationManager.ConnectionStrings[ "myConStr" ].ConnectionString );
        SqlDataAdapter sqlDA = new SqlDataAdapter( "SELECT col1, col2 FROM Table1", sqlCn );
        DataTable dtTemp = new DataTable();
        DataTable dt = new DataTable();
        sqlDA.Fill( dtTemp );
        //Create columns for dt
        dt.Columns.Add( "colA1", typeof( String ) );
        dt.Columns.Add( "colA2", typeof( String ) );
        dt.Columns.Add( "colB1", typeof( String ) );
        dt.Columns.Add( "colB2", typeof( String ) );
        for ( int i = 0; i < dtTemp.Rows.Count; i++ )
        {
            DataRow dr = dt.NewRow();//create a new datarow  for dt
            dr["colA1"] = dtTemp.Rows[i]["col1"];
            dr["colA2"] = dtTemp.Rows[i]["col2"];
            
            i++; //move to next line
            dr["colB1"] = dtTemp.Rows[i]["col1"];
            dr["colB2"] = dtTemp.Rows[i]["col2"];
            dt.Rows.Add( dr );
        }
        //Show the grid 
        GridView1.DataSource = dt;
        GridView1.DataBind();
