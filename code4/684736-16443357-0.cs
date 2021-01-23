     DataRelation customerOrdersRelation =
         customerOrders.Relations.Add("CustOrders",
         customerOrders.Tables["Customers"].Columns["CustomerID"],
         customerOrders.Tables["Orders"].Columns["CustomerID"]);
     foreach (DataRow custRow in customerOrders.Tables["Customers"].Rows)
     {
          // do something with parent row
          foreach (DataRow orderRow in custRow.GetChildRows(customerOrdersRelation))
         {
              // do something with child row
         }
    }
