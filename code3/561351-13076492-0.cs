    foreach (object obj in (ShoppingCart)Session["cart"].Values)
    {
      DataTable dt = new DataTable();
      int productID = (int)obj;
      string query = "SELECT * FROM Products WHERE ProductID = ?";   //yuck, oledb params
      using (OleDbConnection conn = new OleDbConnection (connStr))
      {
         //dont hold me to this syntax, its from my head
         OleDbCommand cmd = new OleDbCommand(query, conn);
         cmd.Parameters.Add(productID);
         OleDbDataAdapter da = new OleDbDataAdapter();
         da.SelectCommand = cm;   
         da.Fill(dt);
      }
      //do something with the data table
    }
