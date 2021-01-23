    private void Open_Database_button_Click(object sender, EventArgs e) 
    { 
        using(OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb" )) 
        using(OleDbCommand Command = new OleDbCommand(" SELECT top 1 * from test", con)) 
        {
           con.Open(); 
           OleDbDataReader DB_Reader = Command.ExecuteReader(); 
           if(DB_Reader.HasRows)
           {
              DB_Reader.Read();
              textbox1.Text = DB_Reader.GetString("your_column_name");
           }
        }  
    }
