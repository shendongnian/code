    var docService = new DocumentsService("company-app-version");
    docService.setUserCredentials("username", "password");
    using Google.GData.Client;
    using Google.GData.Extensions;
    using Google.GData.Documents;
    // snipped method declaration etc
    var docService = new DocumentsService("company-app-version");
    docService.setUserCredentials("username", "password");
    var folderList = docService.Query(new FolderQuery());
    var fLinks = folderList.Entries.Select(e =>
    new
    {
        // note how to get the document Id of the folder
        Id = DocumentsListQuery.DocumentId(e.Id.AbsoluteUri),
        Name = e.Title.Text
    });
    foreach (var folder in fLinks)
    {
        Console.WriteLine("Folder {0}", folder.Name);
        var fileList = docService.Query(
            new SpreadsheetQuery()
            {
                // setting the base address to the folder's URI restricts your results
                BaseAddress = DocumentsListQuery.folderBaseUri + folder.Id
            });
        foreach (var file in fileList.Entries)
        {
            Console.WriteLine(" - {0}", file.Title.Text);
        }
    }
