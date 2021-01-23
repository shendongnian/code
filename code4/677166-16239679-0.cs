    while (reader.Read())
    {                    
    CheckBox1.Checked = (reader.GetBoolean(reader.GetOrdinal("Mount")));
    CheckBox2.Checked = (reader.GetBoolean(reader.GetOrdinal("Braker")));
    CheckBox3.Checked = (reader.GetBoolean(reader.GetOrdinal("Access")));
    CheckBox4.Checked = (reader.GetBoolean(reader.GetOrdinal("Conn_Net")));
    CheckBox5.Checked = (reader.GetBoolean(reader.GetOrdinal("Log_Book")));
    CheckBox6.Checked = (reader.GetBoolean(reader.GetOrdinal("Pictures")));
    CheckBox8.Checked = (reader.GetBoolean(reader.GetOrdinal("Floor")));
    CheckBox9.Checked = (reader.GetBoolean(reader.GetOrdinal("Cb_lenght")));
    CheckBox10.Checked = (reader.GetBoolean(reader.GetOrdinal("Channel")));
    } 
