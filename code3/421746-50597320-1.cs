       using iTextSharp.text;
        using iTextSharp.text.pdf;
        using System.IO;
        using iTextSharp.text.pdf.draw;
    
    Document document = new Document(PageSize.A4,43,43, 43, 43);
    
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(@"D:\abc\text.pdf", FileMode.Create));
    
    
                    PdfPCell cell = null;
                    PdfPTable table = null;
    
                    document.Open();
    
    
                    Chunk glue = new Chunk(new VerticalPositionMark());
    
                    
                    Paragraph para = new Paragraph();
    
                    table = new PdfPTable(1);
                    table.TotalWidth = 340f;
                    table.LockedWidth = true;
                    table.SpacingBefore = 20f;
                    table.HorizontalAlignment = Element.ALIGN_CENTER;
    
                   
                    table.AddCell(PhraseCell(new Phrase("SCHEME INSTALLMENT RECEIPT ", FontFactory.GetFont("Arial", 12,1)), PdfPCell.ALIGN_CENTER));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
    
                    cell.Colspan = 1;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);
    
                    document.Add(table);
    
                    Phrase ph1 = new Phrase();
                    Paragraph mm = new Paragraph();
                    ph1.Add(new Chunk(Environment.NewLine));
                    ph1.Add(new Chunk("Name           : " + name,FontFactory.GetFont("Arial", 10,1)));
                    ph1.Add(glue);
                    ph1.Add(new Chunk("Bill No. :   " + BillNo, FontFactory.GetFont("Arial", 10,1)));
    
                    ph1.Add(new Chunk(Environment.NewLine));
                    ph1.Add(new Chunk("Address      : " + address, FontFactory.GetFont("Arial", 10,1)));
                    ph1.Add(glue);
                    ph1.Add(new Chunk("Bill Date : " + billDate, FontFactory.GetFont("Arial", 10,1)));
    
                    ph1.Add(new Chunk(Environment.NewLine));
                    ph1.Add(new Chunk("Mobile No.  : " + mobile, FontFactory.GetFont("Arial", 10,1)));
                    ph1.Add(glue);
                    ph1.Add(new Chunk("Scheme No. : " + orderNo, FontFactory.GetFont("Arial", 10,1)));
    
                    mm.Add(ph1);
                    para.Add(mm);
                    document.Add(para);
    
    
                    
                
                    table = new PdfPTable(3);
                    
                    table.TotalWidth = 340f;
                    table.LockedWidth = true;
                    table.SpacingBefore = 20f;
                    table.HorizontalAlignment = Element.ALIGN_CENTER;
    
                    table.AddCell(PhraseCell(new Phrase("HSN Code ", FontFactory.GetFont("Arial", 10,1)), PdfPCell.ALIGN_CENTER));
                    table.AddCell(PhraseCell(new Phrase("No of Installment", FontFactory.GetFont("Arial", 10,1)), PdfPCell.ALIGN_CENTER));
                    table.AddCell(PhraseCell(new Phrase("Installment Amount", FontFactory.GetFont("Arial", 10,1)), PdfPCell.ALIGN_CENTER));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    
                    cell.Colspan = 3;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);
    
    
                    
                    table.AddCell(PhraseCell(new Phrase("7113", FontFactory.GetFont("Arial", 10,1)), PdfPCell.ALIGN_CENTER));
                    table.AddCell(PhraseCell(new Phrase(paidNo, FontFactory.GetFont("Arial", 10,1)), PdfPCell.ALIGN_CENTER));
                    table.AddCell(PhraseCell(new Phrase(paidAmount, FontFactory.GetFont("Arial", 10,1)), PdfPCell.ALIGN_CENTER));
                    
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 3;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);
                    
    
                    
    
                    PdfContentByte contentByte = writer.DirectContent;
                    contentByte.MoveTo(45.0, 627.0);
                    contentByte.LineTo(550.0, 627.0);
    
                    document.Add(table);
    
                
                
                    Paragraph para1 = new Paragraph();
                    Phrase ph2 = new Phrase();
                    Paragraph mm1 = new Paragraph();
                    string amountWord = ConvertNumbertoWords(Convert.ToInt64(paidAmount));
                    ph2.Add(new Chunk(Environment.NewLine));
                    ph2.Add(new Chunk(Environment.NewLine));
                    ph2.Add(new Chunk(Environment.NewLine));
                    ph2.Add(new Chunk(amountWord + " Only", FontFactory.GetFont("Arial", 10,1)));
    
                    ph2.Add(new Chunk(Environment.NewLine));
                    ph2.Add(new Chunk("By Cash", FontFactory.GetFont("Arial", 10,1)));
    
                    ph2.Add(new Chunk(Environment.NewLine));
                    ph2.Add(new Chunk(paidAmount, FontFactory.GetFont("Arial", 10,1)));
    
                    mm1.Add(ph2);
                    para1.Add(mm1);
                    document.Add(para1);
    
                    Paragraph para3 = new Paragraph();
                    Phrase ph3 = new Phrase();
                    Paragraph mm3 = new Paragraph();
                    
                    ph3.Add(new Chunk(Environment.NewLine));
                    
    
                    ph3.Add(new Chunk("Credit Card Charges :", FontFactory.GetFont("Arial", 10,1)));
    
                    ph3.Add(new Chunk(Environment.NewLine));
                    ph3.Add(new Chunk("Customer Sign.", FontFactory.GetFont("Arial", 10,1)));
                    ph3.Add(glue);
                    ph3.Add(new Chunk("For Example", FontFactory.GetFont("Arial", 10,1)));
    
                    mm3.Add(ph3);
                    para3.Add(mm3);
                    document.Add(para3);
                
                    document.Close();
