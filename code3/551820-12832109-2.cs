    Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document(MyPdfPath));
    using (FileStream imageStream = new FileStream(MyOutputImage.png, FileMode.Create))
    {
         Resolution resolution = new Resolution(300);
        PngDevice pngDevice = new PngDevice(resolution);
        pngDevice.Process(pdfDocument.Pages[PageNo], MyOutputImage);
        imageStream.Close();
    }
