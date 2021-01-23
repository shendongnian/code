    using(var con = new OracleConnection("ConnectionString Here"))
    using(var cmd = new OracleCommand("ADD YOUR INSERT/UPDATE/DELETE", con))
    {
        con.Open();
        cmd.ExecuteNonQuery();
        using (var cm = new OracleCommand("select round(avg(rating),1) from rates where id_rec = @id", con))
        {
            cm.Parameters.AddWithValue("@id", id);
            using (var reader = cm.ExecuteReader())
            {
                if (reader.Read())
                {
                    textBox5.Text = reader.GetInt16(0).ToString();
                }
            }
        }
    }
