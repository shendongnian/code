    var changes = dataTable.GetChanges(DataRowState.Modified)
        .AsEnumerable()
        .Select(row => new[]{ //create 3 new items for each row
                        new MyClass(row, "Rev/Unit"),
                        new MyClass(row, "Cost/Unit"),
                        new MyClass(row, "Units"),
                    })
        .SelectMany(item => item) //flatten the inner array
        .Where(item => item.From != item.To);
