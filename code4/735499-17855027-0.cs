     private void CreatePdf()
     {
            Document doc = new Document(PageSize.LETTER, 10, 10, 20, 10);
            doc.Open();
            int totalfonts = FontFactory.RegisterDirectory("C:\\WINDOWS\\Fonts");
            StringBuilder sb = new StringBuilder();
            foreach (string fontname in FontFactory.RegisteredFonts)
            {
                sb.Append(fontname + "\n");
            }
            doc.Add(new Paragraph("All Fonts:\n" + sb.ToString()));
            Font arial = FontFactory.GetFont("Arial", 12, BaseColor.GRAY);
            Font verdana = FontFactory.GetFont("Verdana", 20, Font.BOLD | Font.UNDERLINE, new BaseColor(255, 0, 0));
            //rdana.SetStyle(4);
            iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(verdana);
            using (FileStream msReport = new FileStream(Server.MapPath("~") + "/App_Data/" + DateTime.Now.Ticks + ".pdf", FileMode.Create))
            {
                doc.Open();
                PdfWriter pdfWriter = PdfWriter.GetInstance(doc, msReport);
                PdfPCell cell;
                PdfPTable table = new PdfPTable(1);
                cell = new PdfPCell(new Phrase("User I", new Font(verdana)));
                cell.Colspan = 4;
                cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                cell.VerticalAlignment = 1;
                cell.Border = 0;
                table.AddCell(cell);
                table.AddCell(cell);
                doc.Open();
                doc.Add(table);
                doc.Close();
            }
      }
