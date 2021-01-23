    Docs.DocumentsService service = new Docs.DocumentsService("GoogleApiTest");
    service.setUserCredentials("username", "password");
    Docs.DocumentEntry newEntry = new Docs.DocumentEntry();
    newEntry.Title = new Client.AtomTextConstruct(Client.AtomTextConstructElementType.Title, "Test Upload");
    newEntry.Content.Content = "This is a test upload.";
    newEntry.Summary = new Client.AtomTextConstruct(Client.AtomTextConstructElementType.Summary ,"A summary goes here.");
    newEntry.Authors.Add(new Client.AtomPerson(Client.AtomPersonType.Author, "A Person"));
    newEntry.Contributors.Add(new Client.AtomPerson(Client.AtomPersonType.Contributor, "Another Person"));
    newEntry.MediaSource = new Client.MediaFileSource("testDoc.txt", "text/plain");
    Client.ClientLoginAuthenticator authenticator = new Client.ClientLoginAuthenticator("GoogleApiTest", Client.ServiceNames.Documents, service.Credentials);
    Client.ResumableUpload.ResumableUploader uploader = new Client.ResumableUpload.ResumableUploader(512);
    uploader.AsyncOperationProgress += (object sender, Client.AsyncOperationProgressEventArgs e) =>
        {
            Console.WriteLine(e.ProgressPercentage + "%");
        };
    uploader.AsyncOperationCompleted += (object sender, Client.AsyncOperationCompletedEventArgs e) =>
        {
            Console.WriteLine("Upload Complete!");
        };
    Uri uploadUri = new Uri("https://docs.google.com/feeds/upload/create-session/default/private/full?convert=false");
    Client.AtomLink link = new Client.AtomLink(uploadUri.AbsoluteUri);
    link.Rel = Client.ResumableUpload.ResumableUploader.CreateMediaRelation;
    newEntry.Links.Add(link);
    uploader.InsertAsync(authenticator, newEntry, new object());
