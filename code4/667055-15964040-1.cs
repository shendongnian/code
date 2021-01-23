    var pdfReader = new PdfReader(inputPdf);
    using (var ms = new MemoryStream())
    {
            using (var stamp = new PdfStamper(pdfReader, ms))
            {
                foreach (var image in images)
                {
                    var size = pdfReader.GetPageSize(1);
                    var page = pdfReader.NumberOfPages + 1;
                    stamp.InsertPage(page, pdfReader.GetPageSize(1));
                    ImageFormat format = image.PixelFormat == PixelFormat.Format1bppIndexed
                                         || image.PixelFormat == PixelFormat.Format4bppIndexed
                                         || image.PixelFormat == PixelFormat.Format8bppIndexed
                                             ? ImageFormat.Tiff
                                             : ImageFormat.Jpeg;
                    var pdfImage = iTextSharp.text.Image.GetInstance(image, format);
                    pdfImage.Alignment = Element.ALIGN_CENTER;
                    pdfImage.SetAbsolutePosition(0, size.Height - pdfImage.Height);
                    pdfImage.ScaleToFit(size.Width, size.Height);
                    stamp.GetOverContent(page).AddImage(pdfImage);
                }
            }
            ms.Flush();
            return ms.GetBuffer();
    }
