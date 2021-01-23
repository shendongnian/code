    public void CreateDocumentRecurentalTableInTableTest()
    {
    // Structural items are in [], values/data in {}
    //GIVEN (presentation layer)
    //const string FileName = "_6CreateDocumentRecurentalTableInTableTest.txt";
    var doc = new Document();
    var builder = new DocumentBuilder(doc);
    builder.Writeln("TEST -- START");
    builder.InsertField(@"MERGEFIELD TableStart:[MyTable] MERGEFORMAT");
    builder.InsertField(@"MERGEFIELD [MyTableCol1] \* MERGEFORMAT");
    builder.InsertField(@"MERGEFIELD [MyTableCol2] \* MERGEFORMAT");
    builder.Writeln();
    builder.InsertField(@"MERGEFIELD TableStart:[SubTable] MERGEFORMAT");
    builder.InsertField(@"MERGEFIELD [SubTable.Col1] \* MERGEFORMAT");
    builder.InsertField(@"MERGEFIELD [SubTable.Col2] \* MERGEFORMAT");
    builder.InsertField(@"MERGEFIELD TableEnd:[SubTable] MERGEFORMAT");
    builder.Writeln();
    builder.InsertField(@"MERGEFIELD TableEnd:[MyTable] MERGEFORMAT");
    builder.Writeln("\nTEST -- END");
    //WHEN (Data layer)
    DataSet ds = new DataSet();
    var dt = new DataTable("[MyTable]");
    dt.Columns.Add("[MyTableCol1]");
    dt.Columns.Add("[MyTableCol2]");
    dt.Columns.Add("[Id]");
    dt.Rows.Add(" {MyTable.firstRow} ", "", 0);
    dt.Rows.Add(" {MyTable.nextRow} ", "", 1);
    var dt2 = new DataTable("[SubTable]");
    dt2.Columns.Add("[SubTable.Col1]");
    dt2.Columns.Add("[SubTable.Col2]");
    dt2.Columns.Add("[Id]");
    dt2.Rows.Add(" {SubTable.Row1.Cont1} ", " {SubTable.Row1.Cont2} ", 0);
    dt2.Rows.Add(" {SubTable.Row2.Cont1} ", " {SubTable.Row2.Cont2} ", 0);
    dt2.Rows.Add(" {SubTable.Row3.Cont1} ", " {SubTable.Row3.Cont2} ", 0);
    ds.Tables.Add(dt);
    ds.Tables.Add(dt2);
    ds.Relations.Add("MyRelation", dt.Columns[2], dt2.Columns[2], true);
    doc.MailMerge.CleanupOptions = MailMergeCleanupOptions.RemoveUnusedRegions | MailMergeCleanupOptions.RemoveEmptyParagraphs;
    doc.MailMerge.ExecuteWithRegions(ds);
    doc.Save(@"C:\Temp\\out.docx");
    //THEN
    //Assert...
    }
