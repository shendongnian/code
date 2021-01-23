    // Start the service and set credentials
    Docs.DocumentsService service = new Docs.DocumentsService("GoogleApiTest");
    service.setUserCredentials("username", "password");
    // Initialize the DocumentEntry
    Docs.DocumentEntry newEntry = new Docs.DocumentEntry();
    newEntry.Title = new Client.AtomTextConstruct(Client.AtomTextConstructElementType.Title, "Test Upload"); // Set the title
    newEntry.Summary = new Client.AtomTextConstruct(Client.AtomTextConstructElementType.Summary ,"A summary goes here."); // Set the summary
    newEntry.Authors.Add(new Client.AtomPerson(Client.AtomPersonType.Author, "A Person")); // Add a main author
    newEntry.Contributors.Add(new Client.AtomPerson(Client.AtomPersonType.Contributor, "Another Person")); // Add a contributor
    newEntry.MediaSource = new Client.MediaFileSource("testDoc.txt", "text/plain"); // The actual file to be uploading
    // Create an authenticator
    Client.ClientLoginAuthenticator authenticator = new Client.ClientLoginAuthenticator("GoogleApiTest", Client.ServiceNames.Documents, service.Credentials);
    // Setup the uploader
    Client.ResumableUpload.ResumableUploader uploader = new Client.ResumableUpload.ResumableUploader(512);
    uploader.AsyncOperationProgress += (object sender, Client.AsyncOperationProgressEventArgs e) =>
        {
            Console.WriteLine(e.ProgressPercentage + "%"); // Progress updates
        };
    uploader.AsyncOperationCompleted += (object sender, Client.AsyncOperationCompletedEventArgs e) =>
        {
            Console.WriteLine("Upload Complete!"); // Progress Completion Notification
        };
    Uri uploadUri = new Uri("https://docs.google.com/feeds/upload/create-session/default/private/full?convert=false"); // "?convert=false" makes the doc be just a file
    Client.AtomLink link = new Client.AtomLink(uploadUri.AbsoluteUri);
    link.Rel = Client.ResumableUpload.ResumableUploader.CreateMediaRelation;
    newEntry.Links.Add(link);
    uploader.InsertAsync(authenticator, newEntry, new object()); // Finally upload the bloody thing
