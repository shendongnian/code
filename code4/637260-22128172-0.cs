    using System.Windows.Forms; //these two lines should be written before namespace at top of the program
    using System.Data.OleDb;
 
    private void button1_Click(object sender, EventArgs e)
        {        
          System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
         conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data source= C:\Users\pir fahim shah\Documents\PirFahimDataBase.accdb";
   
        try
         {
         conn.Open();
         MessageBox.Show("connected successfuly");
         OleDbDataReader reader  = null;  // This is OleDb Reader
       OleDbCommand cmd = new OleDbCommand("select TicketNo from Table1 where Sellprice='6000' ", conn);
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
         label1.Text= reader["TicketNo"].ToString();           
            
        }
       
    }
        catch (Exception ex)
    {
        MessageBox.Show("Failed to connect to data source");
    }
    finally
    {
        conn.Close();
    }    
     }//end of button click event
