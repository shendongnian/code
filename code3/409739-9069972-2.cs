    Conn.Open();
    using(SqlCommand cmd = connection.CreateCommand())
    {
        cmd.CommandText = "insert into Experimmm (column list) values(@data, @name)";
        cmd.Parameters.Add("@data", SqlDbType.VarBinary).Value = PhotoByte;
        cmd.Parameters.Add("@name", SqlDbType.VarChar, yourlength).Value = textBox1.Text;
 
        cmd.ExecuteNonQuery();
    }
    Conn.Close();
