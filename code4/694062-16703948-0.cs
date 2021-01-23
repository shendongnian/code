    using Novacode;
    using System.Drawing;
    .
    .
    .
    public ActionResult Generar(Documento documento)
    {
        MemoryStream stream = new MemoryStream();
        DocX doc = DocX.Create(stream);
        Paragraph par = doc.InsertParagraph();
        par.Append("This is a dummy test").Font(new FontFamily("Times New Roman")).FontSize(32).Color(Color.Blue).Bold();
        doc.Save();
        return File(stream.ToArray(), "application/octet-stream", "FileName.docx");
    }
