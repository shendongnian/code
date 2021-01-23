    public static byte[] AddPageNumbers(byte[] pdf)
    {
    MemoryStream ms = new MemoryStream();
    // we create a reader for a certain document
    PdfReader reader = new PdfReader(pdf);
    // we retrieve the total number of pages
    int n = reader.NumberOfPages;
    // we retrieve the size of the first page
    Rectangle psize = reader.GetPageSize(1);
    // step 1: creation of a document-object
    Document document = new Document(psize, 50, 50, 50, 50);
    // step 2: we create a writer that listens to the document
    PdfWriter writer = PdfWriter.GetInstance(document, ms);
    // step 3: we open the document
    document.Open();
    // step 4: we add content
    PdfContentByte cb = writer.DirectContent;
    int p = 0;
    Console.WriteLine("There are " + n + " pages in the document.");
    for (int page = 1; page <= reader.NumberOfPages; page++)
    {
        document.NewPage();
        p++;
        PdfImportedPage importedPage = writer.GetImportedPage(reader, page);
        cb.AddTemplate(importedPage, 0, 0);
        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        cb.BeginText();
        cb.SetFontAndSize(bf, 10);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, +p + "/" + n, 7, 44, 0);
        cb.EndText();
    }
    // step 5: we close the document
    document.Close();
    return ms.ToArray();
    }
