    var lastNameGroups = from row in table1.AsEnumerable()
                         group row by new {
                            Name= row.Field<String>("Name"), 
                            LastName = row.Field<String>("LastName")
                         } into LastNameGroups
                         select LastNameGroups;
    var table2 = table1.Clone();
    foreach (var lng in lastNameGroups)
    {
        var row = table2.Rows.Add();
        row.SetField("Name", lng.Key.Name);
        row.SetField("LastName", lng.Key.LastName);
        var ones = lng.Where(r => !string.IsNullOrEmpty(r.Field<String>("1")));
        if(ones.Any())
            row.SetField("1", ones.First().Field<String>("1"));
        var twos = lng.Where(r => !string.IsNullOrEmpty(r.Field<String>("2")));
        if (twos.Any())
            row.SetField("2", twos.First().Field<String>("2"));
        var threes = lng.Where(r => !string.IsNullOrEmpty(r.Field<String>("3")));
        if (threes.Any())
            row.SetField("3", threes.First().Field<String>("3"));
    }
