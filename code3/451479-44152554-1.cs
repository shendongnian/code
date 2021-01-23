    public string MergeFiles(string outputPath)
    {
        if (string.IsNullOrEmpty(outputPath))
            throw new NullReferenceException("Path for output document is null or empty.");
    
        using (Document outputDocument = new Document())
        {
            using (PdfCopy pdf = new PdfCopy(outputDocument, new FileStream(outputPath, FileMode.Create)))
            {
                outputDocument.Open();
                // All bookmarks for output document
                List<Dictionary<string, object>> bookmarks = new List<Dictionary<string, object>>();
                // Bookmarks of the current document
                IList<Dictionary<string, object>> tempBookmarks;
                int pageOffset = 0;
    
                // Merge documents and add bookmarks
                foreach (string file in Files)
                {
                    using (PdfReader reader = new PdfReader(file))
                    {
                        reader.ConsolidateNamedDestinations();
                        // Get bookmarks of current document
                        tempBookmarks = SimpleBookmark.GetBookmark(reader);
    
                        SimpleBookmark.ShiftPageNumbers(tempBookmarks, pageOffset, null);
    
                        pageOffset += reader.NumberOfPages;
                        if(tempBookmarks != null)
                            // Add bookmarks of current document to all bookmarks 
                            bookmarks.AddRange(tempBookmarks);
    
                        // Add every page of document to output document
                        for (int i = 1; i <= reader.NumberOfPages; i++)
                            pdf.AddPage(pdf.GetImportedPage(reader, i));
                     }
                 }
    
                 // Add all bookmarks to output document
                 pdf.Outlines = bookmarks;
             }
        }
    
        return outputPath;
    }
