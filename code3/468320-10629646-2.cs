    var table = new DataTable();
    var marks = new DataColumn("Mark");
    var sections = new DataColumn("Sections");
    
    table.Columns.Add(marks);
    table.Columns.Add(sections);
    
    foreach (var item in result)
    {
        var row = table.NewRow();
        row["Mark"] = item.Mark;
        row["Sections"] = item.Section;
        table.Rows.Add(row);
    }
