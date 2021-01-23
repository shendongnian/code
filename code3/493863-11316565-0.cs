            var output = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Output.pdf");
            var bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            using (FileStream fs = new FileStream(output, FileMode.Create, FileAccess.Write, FileShare.None)) {
                using (Document doc = new Document(PageSize.A4, 2, 2, 10, 10)) {
                    PdfContentByte _pcb;
                    using (PdfWriter writer = PdfWriter.GetInstance(doc, fs)) {
                        //Open document for writing
                        doc.Open();
                        //Insert page
                        doc.NewPage();
                        //Alias to DirectContent
                        _pcb = writer.DirectContent;
                        //Set the font and size
                        _pcb.SetFontAndSize(bf, 12);
                        //Show some text
                        _pcb.BeginText();
                        _pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Page 1", 40, 600, 0);
                        _pcb.EndText();
                        //Insert a new page
                        doc.NewPage();
                        //Re-set font and size
                        _pcb.SetFontAndSize(bf, 12);
                        //Show more text on page 2
                        _pcb.BeginText();
                        _pcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Page 2", 100, 400, 0);
                        _pcb.EndText();
                        doc.Close();
                    }
                }
            }
