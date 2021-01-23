    /// <summary>
    ///   Get all text strings from an XPS file.
    ///   Returns a list of lists (one for each page) containing the text strings.
    /// </summary>
    private static List<List<string>> ExtractTextFromXps(string xpsFilePath)
    {
       var xpsDocument = new XpsDocument(xpsFilePath, FileAccess.Read);
       var fixedDocSeqReader = xpsDocument.FixedDocumentSequenceReader;
       if (fixedDocSeqReader == null)
          return null;
    
       const string UnicodeString = "UnicodeString";
       const string GlyphsString = "Glyphs";
    
       var textLists = new List<List<string>>();
       foreach (IXpsFixedDocumentReader fixedDocumentReader in fixedDocSeqReader.FixedDocuments)
       {
          foreach (IXpsFixedPageReader pageReader in fixedDocumentReader.FixedPages)
          {
             var pageContentReader = pageReader.XmlReader;
             if (pageContentReader == null)
                continue;
    
             var texts = new List<string>();
             while (pageContentReader.Read())
             {
                if (pageContentReader.Name != GlyphsString)
                   continue;
                if (!pageContentReader.HasAttributes)
                   continue;
                if (pageContentReader.GetAttribute(UnicodeString) != null)
                   texts.Add(pageContentReader.GetAttribute(UnicodeString));
             }
             textLists.Add(texts);   
          }
       }
       xpsDocument.Close();
       return textLists;
    }
