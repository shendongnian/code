    Table table = new Table();
    TableRow tableHeader = new TableRow();
    table.AppendChild<TableRow>(tableHeader);
    TableCell tableCell = new TableCell();
    tableHeader.AppendChild<TableCell>(tableCell);
    ParagraphProperties paragraphProperties = new ParagraphProperties();
    Paragraph paragraph = new Paragraph(new Run(new Text("test")));
    JustificationValues? justification = GetJustificationFromString("centre");
    // Use System.Nullable<T>.HasValue instead of the null check.
    if (justification.HasValue)
    {
        // Using System.Nullable<T>.Value to obtain the value and resolve a warning 
        // that occurs when using 'justification' by itself.
        paragraphProperties.AppendChild<Justification>(new Justification() { Val = justification.Value });
    }
    // append the paragraphProperties to the tableCell rather than the paragraph element
    tableCell.AppendChild<ParagraphProperties>(paragraphProperties);
    tableCell.AppendChild<Paragraph>(paragraph);
    Console.WriteLine(table.OuterXml);
