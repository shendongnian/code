    Body bod = doc.MainDocumentPart.Document.Body;
    foreach (Table t in bod.Descendants<Table>().Where(tbl => tbl.InnerText.Contains("myTable")))
    {
        t.Append(new TableRow(new TableCell(new Paragraph(new Run(new Text("test"))))));
    }
