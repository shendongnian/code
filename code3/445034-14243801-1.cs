    private static byte[] CreatePDF(int i)
        {
            byte[] bytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                document.Open();
                document.Add(new Paragraph("Hello World " + i));
                document.Close();
                writer.Close();
                bytes = ms.ToArray();
            }
            return bytes;
        }
