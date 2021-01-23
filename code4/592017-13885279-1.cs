    SqlConnection con = new SqlConnection("your connection string goes here");
    SqlCommand cmd = new SqlCommand(String.Format("select * from {0}",ddlTable.SelectedValue),con);
    SqlDataReader rdr = cmd.ExecuteNonQuery();
    while(rdr.Read())
    {
        //blah blah blah
    }
