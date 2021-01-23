    if (string.IsNullOrEmpty(textBox1.Text) || comboBox3.SelectedIndex != -1 || comboBox4.SelectedIndex != -1 ||
         comboBox5.SelectedIndex != -1 || comboBox8.SelectedIndex != -1)
     {
         MessageBox.Show("Please make sure you don't have any missing fields");
     }
     else
     {
         connection.Open();
    
         //update the settings to the database table 
         MySqlCommand command = connection.CreateCommand();
         // Insert into table_name values ("","name","1")
         command.CommandText = @"insert into CustomTests values ('','" + textBox1.Text + "'," + Convert.ToBoolean(checkBox1.CheckState) + ",'" + comboBox3.Text + "'," + comboBox4.Text + "," + comboBox5.Text + ",'" + comboBox8.Text + "'," + comboBox2.Text + "," + Timer_Enabled + ",'" + comboBox1.Text + "')";
    
         command.ExecuteNonQuery();
     }
