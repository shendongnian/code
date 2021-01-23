    for (int i = 0; i < lstMMVat15SaleDetail.Count; i++) 
    { 
        PdfPCell cell1 = new PdfPCell(new Phrase(lstMMVat15SaleDetail[i].SlNo)); 
        PdfPCell cell2 = new PdfPCell(new Phrase(lstMMVat15SaleDetail[i].Name)); 
        PdfPCell cell3 = new PdfPCell(new Phrase()); 
        cell3.Phrase.Add(new Chunk(lstMainVat15Detail[0].SalesA.ToString())); 
        cell3.Phrase.Add(new Chunk(lstMainVat15Detail[0].SalesB.ToString())); 
        cell3.Phrase.Add(new Chunk(lstMainVat15Detail[0].SalesC.ToString())); 
        cell3.Phrase.Add(new Chunk(lstMainVat15Detail[0].SalesD.ToString())); 
        cell3.Phrase.Add(new Chunk(lstMainVat15Detail[0].SalesE.ToString())); 
        cell3.Phrase.Add(new Chunk(lstMainVat15Detail[0].SalesF.ToString())); 
        cell3.Phrase.Add(new Chunk(lstMainVat15Detail[0].SalesG.ToString())); 
        cell3.Phrase.Add(new Chunk(lstMainVat15Detail[0].SalesH.ToString()));
        myTable.AddCell(cell1); 
        myTable.AddCell(cell2); 
        myTable.AddCell(cell3); 
    } 
