    /* Assuming you have created ClientContext object and Web object*/
    string listTitle = "List title where you want your file to upload";
    string filePath = "your file physical path";
    List oList = web.Lists.GetByTitle(listTitle);
    clientContext.Load(oList.RootFolder);//to load the folder where you will upload the file
    FileCreationInformation fileInfo = new FileCreationInformation();
    fileInfo.Overwrite = true;
    fileInfo.Content = System.IO.File.ReadAllBytes(filePath);
    fileInfo.Url = fileName;
    File fileToUpload = fileCollection.Add(fileInfo);
    clientContext.ExecuteQuery();
    fileToUpload.CheckIn("your checkin comment", CheckinType.MajorCheckIn);
    if (oList.EnableMinorVersions)
    {
        fileToUpload.Publish("your publish comment");
        clientContext.ExecuteQuery();
    }
    if (oList.EnableModeration)
    {
         fileToUpload.Approve("your approve comment"); 
    }
    clientContext.ExecuteQuery();
