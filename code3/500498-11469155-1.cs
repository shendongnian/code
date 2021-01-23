    PdfPTable myTable = new PdfPTable(3);
    myTable.DefaultCell.Padding = 1;
    myTable.DefaultCell.BorderColor = new Color(123, 123, 163);   
    myTable.DefaultCell.Padding = 1;
    myTable.SetWidths(new int[] { 10, 60, 30 });
    myTable.TotalWidth = 100;
    PdfPCell header1 = new PdfPCell(new Phrase("1."));
    PdfPCell header2 = new PdfPCell(new Phrase("SALE DETAILS"));
    PdfPCell header3 = new PdfPCell(new Phrase("AMOUNT"));
    header1.BackgroundColor = iTextSharp.text.Color.GRAY;
    header2.BackgroundColor = iTextSharp.text.Color.GRAY;
    header3.BackgroundColor = iTextSharp.text.Color.GRAY;
    myTable.AddCell(header1);
    myTable.AddCell(header2);
    myTable.AddCell(header3);
    for (int i = 0; i < lstMMVat15SaleDetail.Count; i++)
    {
        PdfPCell cell1 = new PdfPCell(new Phrase(lstMMVat15SaleDetail[i].SlNo));
        // or:   
        // PdfPCell cell1 = new PdfPCell(new Phrase((i + 1).ToString() + "."));
        PdfPCell cell2 = new PdfPCell(new Phrase(lstMMVat15SaleDetail[i].Name));
        PdfPCell cell3 = new PdfPCell(new Phrase(lstMainVat15Detail[0][i].ToString()));
        myTable.AddCell(cell1);
        myTable.AddCell(cell2);
        myTable.AddCell(cell3);
    }
    pdfDoc.Add(myTable);
