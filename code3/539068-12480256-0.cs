    //The code below creates a 2x2 table
    Dim Table = New PdfPTable(2) 
    Table.HorizontalAlignment = 0  //0=Left, 1=Center, 2=Right
    Table.SpacingBefore = 10
    Table.SpacingAfter = 10
    Table.DefaultCell.Border = 0
    Table.SetWidths(New Integer() { 1, 4 })
    Table.AddCell(New Phrase("Content1"))
    Table.AddCell(New Phrase("Content 2"))
    Here comes a huge chunk of business logic. 
     doc.add(table)
     doc.NewPage()
