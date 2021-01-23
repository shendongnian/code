    protected void BindGridview()
    {
    using (SqlConnection con = new SqlConnection("Data Source=DatabaseName;Integrated Security=true;Initial Catalog=***"))//Connection string
    {
    con.Open();
    SqlCommand cmd = new SqlCommand("Select CustomerID,Date,Store,Amount,NoStub  FROM Ticket where ColumnName='"+ YourDrodownId.SlectedValue +"'", con);
    SqlDataReader dr = cmd.ExecuteReader();
    YourGridview.DataSource = dr;
    YourGridview.DataBind();
    con.Close();
    }
    }
