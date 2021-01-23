     protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Identify your control i.e. the primary key (lblbookid is the name of the item template)
        GridViewRow row = GridView1.Rows[e.RowIndex];
        Label bookidLabel = (Label)row.FindControl("lblbookid");
        //connect to db which you probably already have
        string strSQLConnection = ("server=blah;database=blah;uid=blah;pwd=blah");
        SqlConnection sqlConnection = new SqlConnection(strSQLConnection);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "UPDATE yourtable SET book_name = @book_name WHERE book_id = @book_id";
        //parameters
        cmd.Parameters.Add("@bookid", SqlDbType.Char).Value = bookidLabel.Text;
        cmd.Parameters.Add("@book_name", SqlDbType.Char).Value = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
        cmd.Parameters.Add("@book_author", SqlDbType.Char).Value = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
        cmd.Connection = sqlConnection;
        sqlConnection.Open();
        cmd.ExecuteNonQuery();
        
        sqlConnection.Close();
        GridView1.EditIndex = -1;
        BindData();
    }
