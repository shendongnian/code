    using (SqlCommand mySqlCommand = new SqlCommand {Connection = myDatabaseConnection})
    {
        mySqlCommand.CommandText = "Select * from Employee WHERE " + 
        textBox2.Text.Trim() == "" ? "EmpID >= @from" : "EmpID >= @from  AND EmpID <= @to";
        mySqlCommand.CommandType = CommandType.Text;
        mySqlCommand.Parameters.AddWithValue("@from", textBox1.Text.Trim() != "" ? textBox1.Text : int.Parse(textBox2.Text.Trim()) - 3);
        if(textBox2.Text.Trim() != "")
            mySqlCommand.Parameters.AddWithValue("@to", textBox2.Text);
             
        ds = new DataSet();
        adapter = new SqlDataAdapter(mySqlCommand);
        adapter.Fill(ds, "Employee");                    
    }
