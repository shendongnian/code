    public string ExtractTextsFromAllPages(Byte[] pdfBytes)
        {
            var sb = new StringBuilder();
    
            using (var doc = new Doc())
            {
                doc.Read(pdfBytes);
    
                for (var currentPageNumber = 1; currentPageNumber <= doc.PageCount; currentPageNumber++)
                {
                    doc.PageNumber = currentPageNumber;
                    sb.Append(doc.GetText("Text"));
                }
            }
    
            return sb.ToString();
        }
