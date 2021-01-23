     using(SqlConnection cn = GetConnection())
     {
         cn.Open();
         SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Customers", cn);
         DataTable dt = new DataTable();
         da.Fill(dt);
         // At this point dt is filled with datarows extracted from the database in no particular order 
         // And the DefaultView presents the same record organization (or lack of), but...
         // Order on the default view by CustomerName
         dt.DefaultView.Sort = "CustomerName";
         foreach(DataRowView rv in dt.DefaultView)
              Console.WriteLine(rv["CustomerName"].ToString();
         
         // A new dataview with only a certain kind of customers ordered by name
         DataView dvSelectedCust = new DataView(dt, "CreditLevel = 1", "CustomerName", DataViewRowState.Unchanged);
         foreach(DataRowView rv in dvSelectedCust)
              Console.WriteLine(rv["CustomerName"],ToString();
    
  
     }
