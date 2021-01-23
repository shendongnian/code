    string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "table.pdf");
    Document document = new Document();
    FileStream stream = new FileStream(fileName, FileMode.Create);
    var pdfWriter = PdfWriter.GetInstance(document, stream);
    document.Open();
    PdfPTable table = new PdfPTable(4);
    table.Complete = false;
    for (int i = 0; i < 1000000; i++) {
        PdfPCell cell = new PdfPCell(new Phrase(i.ToString()));
        table.AddCell(cell);
        if (i > 0 && i % 1000 == 0) {
            Console.WriteLine(i);
            document.Add(table);
        }
    }
    table.Complete = true;
    document.Add(table);
    document.Close();
