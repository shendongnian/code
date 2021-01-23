    var data = new[] {
        new [] {"Tom",       "30", "x", "",  "1974-06-16"},
        new [] {"Margarita", "34", "x", "x", "1978-10-02"},
        new [] {"Bob",       "7",  "",  "",  "2005-06-26"},
        new [] {"Oleg",      "48", "x", "x", "1964-09-11"},
        new [] {"Frank",     "29", "",  "x", "1983-01-28"}
    };
    using (var stream = new FileStream("Test.xlsx", FileMode.Create)) {
        ExportToExcel.FillSpreadsheetDocument(stream,
            new[] {
                new ColumnModel { Type = DataType.String, Alignment = HorizontalAlignment.Left, Header = "Name" },
                new ColumnModel { Type = DataType.Integer, Header = "Age" },
                new ColumnModel { Type = DataType.String, Header = "Is Married", Alignment = HorizontalAlignment.Center, IsRotatedHeader = true },
                new ColumnModel { Type = DataType.String, Header = "Has Children", Alignment = HorizontalAlignment.Center, IsRotatedHeader = true },
                new ColumnModel { Type = DataType.Date, Header = "Birthday", Alignment = HorizontalAlignment.Left }
            },
            data,
            "Friends");
    }
