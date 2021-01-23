     public string ExtractTextsFromAllPages(string pdfFileName)
        {
            var sb = new StringBuilder();
    
            using (var doc = new Doc())
            {
                doc.Read(pdfFileName);
    
                for (var currentPageNumber = 1; currentPageNumber <= doc.PageCount; currentPageNumber++)
                {
                    doc.PageNumber = currentPageNumber;
                    sb.Append(doc.GetText("Text"));
                }
            }
    
            return sb.ToString();
        }
