    Body bod = doc.MainDocumentPart.Document.Body;
    foreach (Table t in bod.Descendants<Table>().Where(tbl => tbl.GetFirstChild<TableRow>().Descendants<TableCell>().Count() == 4))
    {
        t.Append(new TableRow(new TableCell(new Paragraph(new Run(new Text("test"))))));
    }
