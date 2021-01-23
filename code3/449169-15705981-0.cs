    void SplitePDF(string filepath)
        {
            iTextSharp.text.pdf.PdfReader reader = null;
            int currentPage = 1;
            int pageCount = 0;
            //string filepath_New = filepath + "\\PDFDestination\\";
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            //byte[] arrayofPassword = encoding.GetBytes(ExistingFilePassword);
            reader = new iTextSharp.text.pdf.PdfReader(filepath);
            reader.RemoveUnusedObjects();
            pageCount = reader.NumberOfPages;
            string ext = System.IO.Path.GetExtension(filepath);
            for (int i = 1; i <= pageCount; i++)
            {
                iTextSharp.text.pdf.PdfReader reader1 = new iTextSharp.text.pdf.PdfReader(filepath);
                string outfile = filepath.Replace((System.IO.Path.GetFileName(filepath)), (System.IO.Path.GetFileName(filepath).Replace(".pdf", "") + "_" + i.ToString()) + ext);
                reader1.RemoveUnusedObjects();
                iTextSharp.text.Document doc = new iTextSharp.text.Document(reader.GetPageSizeWithRotation(currentPage));
                iTextSharp.text.pdf.PdfCopy pdfCpy = new iTextSharp.text.pdf.PdfCopy(doc, new System.IO.FileStream(outfile, System.IO.FileMode.Create));
                doc.Open();
                for (int j = 1; j <= 1; j++)
                {
                    iTextSharp.text.pdf.PdfImportedPage page = pdfCpy.GetImportedPage(reader1, currentPage);
                    pdfCpy.SetFullCompression();
                    pdfCpy.AddPage(page);
                    currentPage += 1;
                }
                doc.Close();
                pdfCpy.Close();
                reader1.Close();
                reader.Close();
            }
        }
