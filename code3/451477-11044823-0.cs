    MergePdfFiles(string outputPdf, string[] sourcePdfs)
    {
          PdfReader reader = null;
            Document document = new Document();
            PdfImportedPage page = null;
            PdfCopy pdfCpy = null;
            int n = 0;
            int totalPages = 0;
            int page_offset = 0;
            List<Dictionary<string, object>> bookmarks = new List<Dictionary<string, object>>();
            IList<Dictionary<string, object>> tempBookmarks;
          for (int i = 0; i <= sourcePdfs.GetUpperBound(0); i++)
                    {
                        reader = new PdfReader(sourcePdfs[i]);
                        reader.ConsolidateNamedDestinations();
                        n = reader.NumberOfPages;
                        tempBookmarks = SimpleBookmark.GetBookmark(reader);
                        if (i == 0)
                        {
                        document = new iTextSharp.text.Document(reader.GetPageSizeWithRotation(1));
                            pdfCpy = new PdfCopy(document, new FileStream(outputPdf, FileMode.Create));
                            document.Open();
                            SimpleBookmark.ShiftPageNumbers(tempBookmarks, page_offset, null);
                            page_offset += n;
                            if (tempBookmarks != null)
                                bookmarks.AddRange(tempBookmarks);
                            //  MessageBox.Show(n.ToString());
                            totalPages = n;
                        }
                        else
                        {
                            SimpleBookmark.ShiftPageNumbers(tempBookmarks, page_offset, null);
                            if (tempBookmarks != null)
                                bookmarks.AddRange(tempBookmarks);
                           
                            page_offset += n;
                            totalPages += n;
                        }
                        for (int j = 1; j <= n; j++)
                        {
                            page = pdfCpy.GetImportedPage(reader, j);
                            pdfCpy.AddPage(page);
                        }
                        reader.Close();
                       
                    }
                pdfCpy.Outlines = bookmarks;
                document.Close();
         }
