    Aspose.Pdf.Document document = new Aspose.Pdf.Document(dataDir + "bre25419_cover.pdf");
    //Iterate through All Pages of a PDF Document
    for (int i = 1; i <= document.Pages.Count; i++)
    {
        Aspose.Pdf.Rectangle cropBox = document.Pages[i].CropBox;
        // Crop percentage of width and height
        double percentageX = 4.4f / 100 * cropBox.URX;
        double percentageY = 6.7f / 100 * cropBox.URY;
        // update page's crop box
        document.Pages[i].CropBox = new Aspose.Pdf.Rectangle(cropBox.LLX + percentageX, cropBox.LLY + percentageY, cropBox.URX - percentageX, cropBox.URY - percentageY);
        Console.WriteLine("cropBox.LLX: " + cropBox.LLX + "\ncropBox.LLY: " + cropBox.LLY + "\ncropBox.URX: " + cropBox.URX + "\ncropBox.URY: " + cropBox.URY);
    }
    // save document         
    document.Save(dataDir + "bre25419_cover_Output.pdf");
