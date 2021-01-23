    using (var ms = new MemoryStream())
    {
            var pdf = new PdfReader(inputPdf);
            var doc = new Document(pdf.GetPageSizeWithRotation(1));
            using (var writer = PdfWriter.GetInstance(doc, ms))
            {
                doc.Open();
    
                for (int page = 0; page < pdf.NumberOfPages; page++)
                {
                    doc.SetPageSize(pdf.GetPageSizeWithRotation(page + 1));
                    doc.NewPage();
                    var pg = writer.GetImportedPage(pdf, page + 1);
                    int rotation = pdf.GetPageRotation(page + 1);
                    if (rotation == 90 || rotation == 270)
                        writer.DirectContent.AddTemplate(
                            pg, 0, -1f, 1f, 0, 0, pdf.GetPageSizeWithRotation(page).Height);
                    else
                        writer.DirectContent.AddTemplate(pg, 1f, 0, 0, 1f, 0, 0);
                }
                foreach (var image in images)
                {
                    doc.NewPage();
    
                    ImageFormat format = image.PixelFormat == PixelFormat.Format1bppIndexed
                                         || image.PixelFormat == PixelFormat.Format4bppIndexed
                                         || image.PixelFormat == PixelFormat.Format8bppIndexed
                                             ? ImageFormat.Tiff
                                             : ImageFormat.Jpeg;
                    var pdfImage = iTextSharp.text.Image.GetInstance(image, format);
                    pdfImage.Alignment = Element.ALIGN_CENTER;
                    pdfImage.ScaleToFit(doc.PageSize.Width - 10, doc.PageSize.Height - 10);
                    doc.Add(pdfImage);
                }
                doc.Close();
                writer.Close();
            }
            ms.Flush();
            return ms.GetBuffer();
    }
