    using System.IO;
    public ActionResult DisplayPDF()
    {
        byte[] byteArray = GetPdfFromDB();
        MemoryStream pdfStream = new MemoryStream();
        pdfStream.Write(byteArray , 0,byteArray .Length);
        pdfStream.Position = 0;
        return new FileStreamResult(pdfStream, "application/pdf");
    }
 
