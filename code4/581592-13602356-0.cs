	OracleDataTable dt = new OracleDataTable();
    OracleConnection conn = new OracleConnection();
    conn.ConnectionString = "....string....";
    string query = "SELECT emp_username FROM dc_emp";
    OracleDataAdapter da = new OracleDataAdapter(query,conn);
    da.Fill(dt);
	rp.cbDelivery.DisplayMember = "emp_username";
    rp.cbDelivery.DataSource = dt;
