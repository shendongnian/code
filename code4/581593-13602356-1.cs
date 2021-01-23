    OracleConnection conn = new OracleConnection("....string....");
    string query = "SELECT emp_username FROM dc_emp";
    OracleDataAdapter da = new OracleDataAdapter(query,conn);
    OracleDataTable dt = new OracleDataTable();
    da.Fill(dt);
    rp.cbDelivery.DisplayMember = "emp_username";
    rp.cbDelivery.DataSource = dt;
