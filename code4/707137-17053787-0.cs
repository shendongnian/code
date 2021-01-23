    using (var con = new OleDbConnection("ConnectionString"))
    using (var da = new OleDbDataAdapter("select * from teacher where idteacher=@idTeacher", con))
    {
        da.SelectCommand.Parameters.AddWithValue("@idteacher", idTeacher);
        DataTable table = new DataTable();
        da.Fill(table); // opening or closing connection not needed, done by Fill
        GridView1.DataSource = table;
        GridView1.DataBind();
    }
