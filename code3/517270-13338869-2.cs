    var inputPdf = new PdfReader(inputFile);   // Get input document
    int pageCount = inputPdf.NumberOfPages;
    if (end < start || end > pageCount)
        end = pageCount;
    var inputDoc = new Document(inputPdf.GetPageSizeWithRotation(1)); 
    using (var fs = new FileStream(outputFile, FileMode.Create))
    {
        var outputWriter = PdfWriter.GetInstance(inputDoc, fs);
        inputDoc.Open();
        PdfContentByte cb1 = outputWriter.DirectContent;
        // Copy pages from input to output document
        for (int i = start; i <= end; i++)
        {
            var existingRec = inputPdf.GetPageSizeWithRotation(i);
            var newRec = new Rectangle(0.0f, 0.0f, existingRec.Width + 50, existingRec.Height + 25, 0);
            
            inputDoc.SetPageSize(newRec);
            inputDoc.NewPage();
            PdfImportedPage page = outputWriter.GetImportedPage(inputPdf, i);
            int rotation = inputPdf.GetPageRotation(i);
            if (rotation == 90 || rotation == 270)
                 cb1.AddTemplate(page, 0, -1f, 1f, 0, 0, inputPdf.GetPageSizeWithRotation(i).Height);
            else cb1.AddTemplate(page, 1f, 0, 0, 1f, 25, 13); 
        }
        inputDoc.Close();
    }
