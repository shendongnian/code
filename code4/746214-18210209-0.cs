    Aspose.Pdf.Document document = new Aspose.Pdf.Document(dataDir + "bre25419_cover.pdf");
    //Iterate through All Pages of a PDF Document
    for (int i = 1; i <= document.Pages.Count; i++)
    {
        Aspose.Pdf.Rectangle cropBox = document.Pages[i].CropBox;
        // update page's crop box
        document.Pages[i].CropBox = new Aspose.Pdf.Rectangle(cropBox.LLX + 72, cropBox.LLY + 72, cropBox.URX - 72, cropBox.URY - 72);
    }
    // save document         
    document.Save(dataDir + "bre25419_cover_Output.pdf");
