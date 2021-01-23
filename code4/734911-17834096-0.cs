    foreach (DataTable table in resultingMessage.Tables)
    {
       foreach (DataRow row in table.Rows)
       {
         foreach (object item in row.ItemArray)
         {
            // read item
            var loginState = item.LoginState;
         }
       }
    }
