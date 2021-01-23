            //TODO:
            string yourOutFile = @"c:\file.pdf"; //Your file
            int nPaginasPDF = 0; //Your counter
            using (var fs = new System.IO.FileStream(yourOutFile, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None)) {
                using (var doc = new Document()) {
                    using (var writer = PdfWriter.GetInstance(doc, fs)) {
                        doc.Open();
                        for (int iCnt = 0; iCnt < nPaginasPDF; iCnt++) {
                            iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance("C:\\" + (iCnt + 1) + ".bmp");
                            image1.ScalePercent(23f);
                            doc.NewPage();
                            doc.Add(image1);
                        }
                        doc.Close();
                    }
                }
            }
