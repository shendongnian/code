    string item = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
    
    string h="update Follow_Date set @Current_Date, @Current_Time, @Type, @Remarks, @Next_Follow_Date where @Follow_Id";
    
    try
    {
    Using (OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\lernovo\Documents\JDB.mdb"))
    {
      con.Open();
    
      Using (OleDbCommand cmd = new OleDbCommand(h, con))
      {    
        cmd.Parameters.Add("Current_Date", dateTimePicker1.Value.ToLongDateString());
        cmd.Parameters.Add("Current_Time", dateTimePicker3.Value.ToLongTimeString());
        cmd.Parameters.Add("Remarks", textBox1.Text);
        cmd.Parameters.Add("Type", comboBox1.SelectedItem.ToString());
        cmd.Parameters.Add("Next_Follow_Date", dateTimePicker2.Value.ToLongDateString());
        cmd.Parameters.Add("Follow_Id", item.ToString());
        cmd.ExecuteNonQuery();
      }
    }
    }
    catch(SQLException ex)
    {
    System.Console.WriteLine(ex.Message, ex.StackaTrace)
    }
