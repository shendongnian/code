       string sql=string.Format("UPDATE Table1 SET column1='{0}',column2='{1}' where id={2}",tbx1.text,tbx2.text,tbx3.text);
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = strconn4;
          SqlCommand cmd = new SqlCommand();
                 cmd.CommandText = sql;
                 cmd.Connection = conn;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
