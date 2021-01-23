            string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.pdf");
            using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
                using (Document doc = new Document(PageSize.LETTER)) {
                    using (PdfWriter writer = PdfWriter.GetInstance(doc, fs)) {
                        doc.Open();
                        //This creates two lines of text using the iTextSharp abstractions
                        doc.Add(new Paragraph("This is Paragraph 1"));
                        doc.Add(new Paragraph("This is Paragraph 2"));
                        //This does the same as above but line spacing needs to be calculated manually
                        PdfContentByte cb = writer.DirectContent;
                        cb.SaveState();
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 12f);
                        cb.BeginText();
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "This is cb1", 20, 311, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "This is cb2", 20, 291, 0);//Just guessing that line two should be 20px down, will actually depend on the font
                        cb.EndText();
                        cb.RestoreState();
                        doc.Close();
                    }
                }
            }
