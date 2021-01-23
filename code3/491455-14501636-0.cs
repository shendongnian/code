    @{
        var properties = typeof(MyModelClassName).GetProperties();
        var webGridColumns = properties.Select(prop => new WebGridColumn()
            {
                ColumnName = prop.Name, Header = prop.Name, Style = "my-style"
            }).ToList();
        var grid = new WebGrid(source: Model, rowsPerPage: 3);
        @grid.GetHtml(tableStyle: "grid",
                      headerStyle: "head",
                      alternatingRowStyle: "alt",
                      columns: webGridColumns)
    }
