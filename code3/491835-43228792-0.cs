     DataTable dt = new DataTable();
     dt.Columns.Add("Item_Id", typeof(string));
     dt.Columns.Add("Categry", typeof(string));
     dt.Columns.Add("Item_Name", typeof(string));
     dt.Columns.Add("Unit_Price", typeof(double));
     dt.Columns.Add("Quantity", typeof(int));
     dt.Columns.Add("Discount", typeof(string));
     dt.Columns.Add("Total_Payable", typeof(double));
      foreach (DataGridViewRow dgr in DGVsell.Rows) 
     {
       dt.Rows.Add(dgr.Cells[0].Value, dgr.Cells[1].Value, dgr.Cells[2].Value, dgr.Cells[3].Value, dgr.Cells[4].Value, dgr.Cells[5].Value, dgr.Cells[6].Value);
     }
     ds.Tables.Add(dt);
     ds.WriteXmlSchema("Bill.xml");
