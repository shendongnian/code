    Google.Apis.Drive.v2.Data.File folder = new Google.Apis.Drive.v2.Data.File();
    folder.Title = "My first folder";
    folder.Description = "folder document description";
    folder.MimeType = "application/vnd.google-apps.folder";
    // service is an authorized Drive API service instance
    Google.Apis.Drive.v2.Data.File file = service.Files.Insert(folder).Fetch();
    
    Google.Apis.Drive.v2.Data.File theImage = new Google.Apis.Drive.v2.Data.File();
    theImage.Title = "My first image";
    theImage.MimeType = "image/jpeg";
    theImage.Parents = new List<ParentReference>()
       { new ParentReference() {Id = file.id} };
    byte[] byteArray = System.IO.File.ReadAllBytes("Bluehills.jpg");
    System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
    FilesResource.InsertMediaUpload request = service.Files.Insert(theImage, stream, "image/jpeg");
    request.Upload();
    Google.Apis.Drive.v2.Data.File imageFile = request.ResponseBody;
    Console.WriteLine("File id: " + imageFile.Id);
    Console.WriteLine("Press Enter to end this process.");
    Console.ReadLine();
