    string sql = "SELECT Columns FROM dbo.TableName WHERE Column=@ParamName";
    using (var con = new SqlConnection("Connection String Here"))
    using (var da = new SqlDataAdapter(sql, con))
    {
        da.SelectCommand.Parameters.AddWithValue("@ParamName", "Param Value");
        // other parameters
        DataTable table = new DataTable();
        da.Fill(table);
        dataGridView1.DataSource = table;             
    }
