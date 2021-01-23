      // Presuming the DataTable has a column named Date. 
      string expression = "Date = '1/31/1979' or OrderID = 2";
      // string expression = "OrderQuantity = 2 and OrderID = 2";
      // Sort descending by column named CompanyName. 
      string sortOrder = "CompanyName ASC";
      DataRow[] foundRows;
      // Use the Select method to find all rows matching the filter.
      foundRows = table.Select(expression, sortOrder);
