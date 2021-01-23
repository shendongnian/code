    private const string CONN_STR = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= c:\\Users\\Acer\\Documents\\HotelCustomersOld.mdb";
    private string GetCheckInTime(string roomNumber) {
      string sql = "SELECT [Time Checked-In] AS CheckIN FROM HotelCustomers WHERE [Room Number] =" + roomNumber + ";";
      object obj = null;
      using (var cmd = new OleDbCommand(sql, new OleDbConnection(CONN_STR))) {
        cmd.Connection.Open();
        obj = cmd.ExecuteScalar();
        cmd.Connection.Close();
      }
      if ((obj != null) && (obj != DBNull.Value)) {
        return obj.ToString();
      }
      return null;
    }
