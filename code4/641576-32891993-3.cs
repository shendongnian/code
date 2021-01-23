    public static void CropDocument(string file, string oldchar, string repChar)
    {
        int pageNumber = 1;
        PdfReader reader = new PdfReader(file);
        iTextSharp.text.Rectangle size = new iTextSharp.text.Rectangle(
        Globals.fX,
        Globals.fY,
        Globals.fWidth,
        Globals.fHeight);
        Document document = new Document(size);
        PdfWriter writer = PdfWriter.GetInstance(document,
        new FileStream(file.Replace(oldchar, repChar),
        FileMode.Create, FileAccess.Write));
        document.Open();
        PdfContentByte cb = writer.DirectContent;
        document.NewPage();
        PdfImportedPage page = writer.GetImportedPage(reader,
        pageNumber);
        cb.AddTemplate(page, 0, 0);
        document.Close();
    }
