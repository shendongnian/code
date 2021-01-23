    SqlConnection conn = new SqlConnection();
    conn.ConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\MyDB.mdf;Integrated Security=True";
    
    try
    {
       conn.Open();
       SqlCommand Command = conn.CreateCommand();
       Command.CommandText = "DELETE FROM Contacts WHERE [First Name] = Name;"; // You don't need the '' or the '@' in your parameter name.
       Command.Parameters.AddWithValue("@Name", comboBox1.SelectedValue);
       if (Command.ExecuteNonQuery() > 0)  //  Add a conditional here that checks for > 0 and THEN set your validation text.
          textBox1.Text = comboBox1.SelectedValue + " Has Been Deleted";
    }
    catch (Exception ex)
    {
       textBox1.Text = "Nope";
    }
    
    finally
    {
       conn.Close();
    } 
