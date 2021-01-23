    private void Timer1_tick(object sender, EventArgs e) 
    { 
        using(FbConnection UpdateConnection = new FbConnection(ConnectionString))
        {
            UpdateConnection.Open(); 
            FbCommand writeCommand = new FbCommand("UPDATE Param SET Test=@myData", UpdateConnection); 
            writeCommand.Parameters.Add("@myData", TextBox1.Text);
            writeCommand.ExecuteNonQuery(); 
        }
    } 
