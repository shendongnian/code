    private void CreatePdf()
    {
            using (FileStream msReport = new FileStream(Server.MapPath("~") + "/App_Data/" + DateTime.Now.Ticks + ".pdf", FileMode.Create))
            {
                Document doc = new Document(PageSize.LETTER, 10, 10, 20, 10);
                PdfWriter pdfWriter = PdfWriter.GetInstance(doc, msReport);
                doc.Open();
                PdfPTable pt = new PdfPTable(1);
                PdfPCell _cell;
                _cell = new PdfPCell(new Phrase("789456|Test"));
                _cell.VerticalAlignment = Element.ALIGN_RIGHT;
                _cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _cell.Border = 0;
                pt.AddCell(_cell);
                _cell = new PdfPCell(new Phrase("456|Test"));
                _cell.VerticalAlignment = Element.ALIGN_RIGHT;
                _cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _cell.Border = 0;
                pt.AddCell(_cell);
                _cell = new PdfPCell(new Phrase("12345|Test"));
                _cell.VerticalAlignment = Element.ALIGN_RIGHT;
                _cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _cell.Border = 0;
                pt.AddCell(_cell);
                doc.Open();
                doc.Add(pt);
                doc.Close();
          }
    }
