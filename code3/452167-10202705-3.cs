    var query = from consumer in Tb_Consumer.AsEnumerable()
                select new
                {
                   CityName = consumer.Field<string>("City"),
                   //Name of relationship i.e. relation1 is important here
                   Sales = consumer.GetChildRows("relation1").Sum(tx=> tx.Field<decimal>("Price")) 
                };
    var datatable = new DataTable();
    col = new DataColumn("City");
    datatable.Columns.Add(col);
    col = new DataColumn("TotalSales");
    datatable.Columns.Add(col);
    
    foreach (var item in query.ToList())
    {
        var newrow = datatable.NewRow();
        newrow["City"] = item.CityName;
        newrow["TotalSales"] = item.Sales;
        datatable.Rows.Add(newrow);
    }   
