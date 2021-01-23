    public DocumentsFeed RetrieveDocsInFolder(DocumentsService service, string folder)
    {
        string uri = String.Format(DocumentsListQuery.foldersUriTemplate, folder);
        DocumentsListQuery query = new DocumentsListQuery(uri);
        return service.Query(query);
    }
