    var drdatedisp = from row in dtfullreport.AsEnumerable()
                      group row by row.Field<string>("Order_Date") into g
                      select new
                      {
                          Order_Date = g.Key,
                          totalAmt = g.Sum(a => a.Field<int>("Item_Quantity"))
                                 
                      };
     DataTable dtdatedisp = new DataTable();
     dtdatedisp.Columns.Add("Order_Date");
     dtdatedisp.Columns.Add("Quantity");
     dtdatedisp.Rows.Clear();
     foreach (var g in drdatedisp)
     {
         DataRow newRow1 = dtdatedisp.NewRow();
         newRow1[0] = g.Order_Date;
         newRow1[1] = g.totalAmt;
         dtdatedisp.Rows.Add(newRow1);
     }
