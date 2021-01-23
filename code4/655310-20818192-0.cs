    BaseFont basefontArabic = BaseFont.CreateFont("c:\\\\windows\\\\fonts\\\\TIMES.ttf", BaseFont.IDENTITY_H, true);
    iTextSharp.text.Font farabicNormal = new iTextSharp.text.Font(basefontArabic, 10, iTextSharp.text.Font.NORMAL);
    iTextSharp.text.Font farabicBold = new iTextSharp.text.Font(basefontArabic, 12, iTextSharp.text.Font.BOLD);
     `Document document = new Document(PageSize.A4);
                    document.SetMargins(10f, 10f, 10f, 30f);
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(FileName+ ".pdf", FileMode.Create));
                    PageEventHelper pageEventHelper = new PageEventHelper();
                    writer.PageEvent = pageEventHelper;
                    pageEventHelper.tab = ReportDesigner.GetHeaderFacture(f);
                    document.Open();
    
                    PdfPTable table = new PdfPTable(5) { RunDirection = PdfWriter.RUN_DIRECTION_RTL, HeaderRows = 1 };
                    table.SetWidths(new float[] { 1, 1, 1, 2, 1 });
    
                    table.AddCell(new PdfPCell(new Phrase("الكمية", ReportDesigner.farabicNormal)) { GrayFill = 0.95f, HorizontalAlignment=Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase("نوع السلعة", ReportDesigner.farabicNormal)) { GrayFill = 0.95f, HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase("الوزن الصافي", ReportDesigner.farabicNormal)) { GrayFill = 0.95f, HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase("س . ف", ReportDesigner.farabicNormal)) { GrayFill = 0.95f, HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase("الجملة", ReportDesigner.farabicNormal)) { GrayFill = 0.95f, HorizontalAlignment = Element.ALIGN_CENTER });
    
                    foreach (OrderDetailsEntity item in Order.Details)
                    {
                        table.AddCell(new PdfPCell(new Phrase(item.Quantité.ToString("N3"), ReportDesigner.farabicNormal)));
                        table.AddCell(new PdfPCell(new Phrase(item.ArticleLigneFacture.Désignation, ReportDesigner.farabicNormal)));
                        table.AddCell(new PdfPCell(new Phrase(item.QantitéEmballage.ToString("N3"), ReportDesigner.farabicNormal)));
                        table.AddCell(new PdfPCell(new Phrase(item.PrixAchatUnitaire.ToString("N3"), ReportDesigner.farabicNormal)));
                        table.AddCell(new PdfPCell(new Phrase(item.TotalLigneFacture.ToString("N3"), ReportDesigner.farabicNormal)));
                    }
    document.Add(table);
                    document.Close();`  
