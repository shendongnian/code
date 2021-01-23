    cell = New PdfPCell();
    p = New Phrase("value");
    cell.AddElement(p);
    cell.HorizontalAlignment = Element.ALIGN_CENTER; //Tried with Element.Align_Center Also. Tried Adding this line before adding element also. 
    table.AddCell(cell);
