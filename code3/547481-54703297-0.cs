    var myTable = new PdfPTable( 3 );
    
    foreach(var nextString in myStrings)
    {
    
        var nextCell = new PdfPCell( new Phrase( nextString, smallFont ) );
        nextCell.Border = Rectangle.NO_BORDER;
        nextCell.AddCell(nextCell);
    }
    myTable.DefaultCell.Border = Rectangle.NO_BORDER;
    myTable.CompleteRow();
    
    pdfDocument.Add(myTable);
