            string testFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Doc1.pdf");
            string outputPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            int pageNum = 1;
            PdfReader pdf = new PdfReader(testFile);
            PdfDictionary pg = pdf.GetPageN(pageNum);
            PdfDictionary res = (PdfDictionary)PdfReader.GetPdfObject(pg.Get(PdfName.RESOURCES));
            PdfDictionary xobj = (PdfDictionary)PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT));
            if (xobj == null) { return; }
            foreach (PdfName name in xobj.Keys) {
                PdfObject obj = xobj.Get(name);
                if (!obj.IsIndirect()) { continue; }
                PdfDictionary tg = (PdfDictionary)PdfReader.GetPdfObject(obj);
                PdfName type = (PdfName)PdfReader.GetPdfObject(tg.Get(PdfName.SUBTYPE));
                if (!type.Equals(PdfName.IMAGE)) { continue; }
                int XrefIndex = Convert.ToInt32(((PRIndirectReference)obj).Number.ToString(System.Globalization.CultureInfo.InvariantCulture));
                PdfObject pdfObj = pdf.GetPdfObject(XrefIndex);
                PdfStream pdfStrem = (PdfStream)pdfObj;
                byte[] bytes = PdfReader.GetStreamBytesRaw((PRStream)pdfStrem);
                if (bytes == null) { continue; }
                using (System.IO.MemoryStream memStream = new System.IO.MemoryStream(bytes)) {
                    memStream.Position = 0;
                    System.Drawing.Image img = System.Drawing.Image.FromStream(memStream);
                    if (!Directory.Exists(outputPath))
                        Directory.CreateDirectory(outputPath);
                    string path = Path.Combine(outputPath, String.Format(@"{0}.jpg", pageNum));
                    System.Drawing.Imaging.EncoderParameters parms = new System.Drawing.Imaging.EncoderParameters(1);
                    parms.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Compression, 0);
                    var jpegEncoder = ImageCodecInfo.GetImageEncoders().ToList().Find(x => x.FormatID == ImageFormat.Jpeg.Guid);
                    img.Save(path, jpegEncoder, parms);
                }
            }
