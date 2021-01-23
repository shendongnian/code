    public IDocumentListCollection getDocumentCollection(string ProjectID, SearchQuery query)
    {
         IDocumentListCollection rtnVal;
         try
         {
            rtnVal = DocumentService().FindDocuments("", ProjectID, true, true);
         }
         catch(Exception e)
         {
             rtnVal = new DocumentListCollection(); //Or any other stubbed version.
         }
         return rtnVal;
    }
