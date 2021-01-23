    List<IElement> list = HTMLWorker.ParseToList(new StringReader(resultCache), ST);
    doc.Open();
    //Use a table so that we can set the text direction
    PdfPTable table = new PdfPTable(1);
    //Ensure that wrapping is on, otherwise Right to Left text will not display
    table.DefaultCell.NoWrap = false;
    table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
    //Loop through each element, don't bother wrapping in P tags
    foreach (var element in list)
    {
        //Create a cell and add text to it
        PdfPCell text = new PdfPCell(new Phrase(element, font));
        //Ensure that wrapping is on, otherwise Right to Left text will not display
        text.NoWrap = false;
        //Add the cell to the table
        table.AddCell(text);
    }
    //Add the table to the document
    document.Add(table);
    doc.Close();
    pdfWriter.Close();
