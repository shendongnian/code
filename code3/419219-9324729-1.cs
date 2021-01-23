    SqlCeConnection connection = new SqlCeConnection("Data Source = mainDB.sdf");
    connection.Open();
    using (SqlCeCommand com = new SqlCeCommand("INSERT INTO Users (Name, Surname, Nickname, Gender, Status, City, Photo) Values(@name,@surname,@nickname,@gender,@status,@city,@photo)", connection))
    {
        com.Parameters.AddWithValue("@name", textBox1.Text);
        com.Parameters.AddWithValue("@surname", textBox2.Text);
        com.Parameters.AddWithValue("@nickname", textBox3.Text);
        com.Parameters.AddWithValue("@gender", listBox1.Text.Length > 0 ? listBox1.Text : null);
        com.Parameters.AddWithValue("@status", radioButton1.Checked ? "Student" : radioButton2.Checked ? "Professional" : null);
        com.Parameters.AddWithValue("@city", comboBox1.Text.Length > 0 ? comboBox1.Text : null);
        com.Parameters.AddWithValue("@photo", im);
                    
        com.ExecuteNonQuery();
    }
    connection.Close();
