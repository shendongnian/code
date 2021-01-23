    var grouped = table.AsEnumerable()
                       .GroupBy(r => f.Field<String>("Currency"))
                       .Select( g => new  { 
                                Currency = g.Key, 
                                Amount = g.Sum(r => r.Field<int>("amount")) 
                       });
    
    var table2 = table.Clone(); // you can also just use the original table, i just didn't want to merge the data here
    foreach(var grp in grouped)
    {
        var newRow = table2.Rows.Add();
        newRow.SetField("Currency") = grp.Currency;
        newRow.SetField("amount") = grp.amount;
    }
