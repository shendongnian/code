    public static byte[] MergeFiles(List<byte[]> sourceFiles)
        {
            Document document = new Document();
            MemoryStream output = new MemoryStream();
    
            try
            {
                // Initialize pdf writer
                PdfWriter writer = PdfWriter.GetInstance(document, output);
                // Open document to write
                document.Open();
                PdfContentByte content = writer.DirectContent;
    
                // Iterate through all pdf documents
                for (int fileCounter = 0; fileCounter < sourceFiles.Count; fileCounter++)
                {
                    // Create pdf reader
                    PdfReader reader = new PdfReader(sourceFiles[fileCounter]);
                    int numberOfPages = reader.NumberOfPages;
    
                    // Iterate through all pages
                    for (int currentPageIndex = 1; currentPageIndex <=
                                       numberOfPages; currentPageIndex++)
                    {
                        // Determine page size for the current page
                        document.SetPageSize(
                           reader.GetPageSizeWithRotation(currentPageIndex));
    
                        // Create page
                        document.NewPage();
                        PdfImportedPage importedPage =
                          writer.GetImportedPage(reader, currentPageIndex);
    
    
                        // Determine page orientation
                        int pageOrientation = reader.GetPageRotation(currentPageIndex);
                        if ((pageOrientation == 90) || (pageOrientation == 270))
                        {
                            content.AddTemplate(importedPage, 0, -1f, 1f, 0, 0,
                               reader.GetPageSizeWithRotation(currentPageIndex).Height);
                        }
                        else
                        {
                            content.AddTemplate(importedPage, 1f, 0, 0, 1f, 0, 0);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("There has an unexpected exception" +
                      " occured during the pdf merging process.", exception);
            }
            finally
            {
                document.Close();
            }
            return output.GetBuffer();
        }
