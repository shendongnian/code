    var tables = mainPart.Document.Descendants<Table>().ToList();
    List<TableCell> cellList = new List<TableCell>();
    foreach (Table t in tables)
    {
        var rows = t.Elements<TableRow>();
        foreach (TableRow row in rows)
        {
            var cells = row.Elements<TableCell>();
            foreach (TableCell cell in cells) 
            cellList.Add(cell);
        }
    }
    var q = from c in cellList where c.InnerText == "Testing123" || 
                                     c.InnerText == "TestingOMG!" 
            select c.Parent.Parent;
    
    String xml = q.First().OuterXml;
    
