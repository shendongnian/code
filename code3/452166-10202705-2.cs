    var datatable = new DataTable();
            var col = new DataColumn("City");
            datatable.Columns.Add(col);
            col = new DataColumn("TotalSales");
            datatable.Columns.Add(col);
    
            foreach(var item in query.ToList())
            {
                var newrow = datatable.NewRow();
                newrow["City"] = item.CityName;
                newrow["TotalSales"] = item.Sales;
                datatable.Rows.Add(newrow);
            }
