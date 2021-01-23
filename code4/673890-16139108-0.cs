    using (OleDbConnection conn = new OleDbConnection(ConnString))
     {
           conn.Open();
           OleDbCommand cmd = conn.CreateCommand();
           cmd.CommandText = "UPDATE Account SET Cash=? WHERE AccountID =?";
           cmd.Parameters.Add("@p1", OleDbType.Decimal).Value = 3.1416;
           cmd.Parameters.Add("@p2", OleDbType.Integer).Value = accountName;
           cmd.ExecuteNonQuery();
     }
