    conn = new SqlConnection();
    conn.ConnectionString = "my connection string";
    SqlDataAdapter da = new SqlDataAdapter("Select (FName+' '+Surname) As Name,customerID from Customer", conn);
    DataTable dt = new DataTable();
    da.Fill(dt);
    comboSelectCust.DisplayMember = "Name";
    comboSelectCust.ValueMember = "customerID";
    comboSelectCust.DataSource = dt;
