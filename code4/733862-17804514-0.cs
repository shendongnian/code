    String strSQL = @"SELECT TOP 4 staffID FROM staff ORDER BY staffID DESC";
    using(var myCommand = new SqlCommand(strSQL, myConn))
    using(var dataAdapter = new SqlDataAdapter(myCommand))
    {
        DataTable table = new DataTable();
        dataAdapter.Fill(table);
        Label1.Text = table.Rows[0]["staffID"].ToString();
        Label2.Text = table.Rows[1]["staffID"].ToString();  
        Label3.Text = table.Rows[2]["staffID"].ToString();
        Label4.Text = table.Rows[3]["staffID"].ToString();
    } 
