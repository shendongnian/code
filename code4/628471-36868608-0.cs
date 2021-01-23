    using ExcelDna.Integration;
    using Excel = Microsoft.Office.Interop.Excel;
    [ExcelFunction(Category = "Foo", Description = "Sets value of cell")]
    public static Foo(String idx)
    {
        Excel.Application app = (Excel.Application)ExcelDnaUtil.Application;
        Excel.Range range = app.ActiveCell;
        object[2,2] dummyData = new object[2, 2] {
            { "foo", "bar" },
            { 2500, 7500 }
        };
        var reference = new ExcelReference(
            range.Row, range.Row + 2 - 1, // from-to-Row
            range.Column - 1, range.Column + 2 - 1); // from-to-Column
        // Cells are written via this async task
        ExcelAsyncUtil.QueueAsMacro(() => { reference.SetValue(dummyData); });
        // Value displayed in the current cell. 
        // It still is a UDF and can be executed multiple times via F2, Return.
        return "=Foo()";
    }
