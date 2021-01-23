                string original = args[0];
                string inPDF = original;
                string outPDF = Directory.GetDirectoryRoot(original) + "temp.pdf";
                PdfReader pdfr = new PdfReader(inPDF);
                Document doc = new Document(PageSize.LETTER);
                Document.Compress = true;
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(outPDF, FileMode.Create));
                doc.Open();
                PdfContentByte cb = writer.DirectContent;
                PdfImportedPage page;
                for (int i = 1; i < pdfr.NumberOfPages + 1; i++)
                {
                    page = writer.GetImportedPage(pdfr, i);
                    cb.AddTemplate(page, PageSize.LETTER.Width / pdfr.GetPageSize(i).Width, 0, 0, PageSize.LETTER.Height / pdfr.GetPageSize(i).Height, 0, 0);
                    doc.NewPage();
                }
                doc.Close();
                //just renaming, conversion / resize process ends at doc.close() above
                File.Delete(original);
                File.Copy(outPDF, original);
