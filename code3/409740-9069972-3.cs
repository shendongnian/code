    byte[] data;
    string name;
    Conn.Open();
    using(SqlCommand cmd = Conn.CreateCommand())
    {    
        cmd.CommandText = "select column_list from Experimmm where id = @id";
        cmd.Parameters.Add("@id", SqlDbType.VarChar, field_length).Value = textBox2.Text;
        using(SqlDataReader dr = cmd.ExecuteReader())
        {
            if (dr.Read())
            {
                data = (byte[])dr.GetValue(0); 
                name = (string)dr.GetValue(1);
            }
        }
    }
    Conn.Close();
    label1.Text = name;
    pictureBox2.Image = Image.FromStream(new MemoryStream(data));
