    var sourceFileList = new List<string>();
    //add files to merge
    int sourceIndex = 0;
    PdfReader reader = new PdfReader(sourceFileList[sourceIndex]);
    int sourceFilePageCount = reader.NumberOfPages;
    Document doc = new Document(reader.GetPageSizeWithRotation(1));
    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(destinationFileName, FileMode.Create));
    doc.Open();
    PdfImportedPage page;
    PdfContentByte contentByte = writer.DirectContent;                
    int rotation;
    while (sourceIndex < sourceFileList.Count)
    {
        int pageIndex = 0;
        while (pageIndex < sourceFilePageCount)
        {
            pageIndex++;
            doc.SetPageSize(reader.GetPageSizeWithRotation(pageIndex));
            doc.NewPage();
            page = writer.GetImportedPage(reader, pageIndex);
            rotation = reader.GetPageRotation(pageIndex);
            if (rotation.Equals(90 | 270))
                contentByte.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(pageIndex).Height);
            else
                contentByte.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
        }
        sourceIndex++;
        if (sourceIndex < sourceFileList.Count)
        {
            reader = new PdfReader(sourceFileList[sourceIndex]);
            sourceFilePageCount = reader.NumberOfPages;
        }
    }
    doc.Close();
