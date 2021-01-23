       string sql = " DELETE FROM HotelCustomers WHERE [Room Number] =?";
       using(OleDbConnection My_Connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= c:\\Users\\Documents\\HotelCustomersOld.mdb"))
       {
            My_Connection.Open();
            OleDbCommand My_Command = new OleDbCommand(sql, My_Connection);
            My_Command.Parameters.Add("@p1",  textBox1.Text);
            My_Command.ExecuteNonQuery();
       }
