    string folderPath = Server.MapPath("/testsite/admin/upload/users/" + username);
    bool IsExists = System.IO.Directory.Exists(folderPath);
    if(!IsExists)
        System.IO.Directory.CreateDirectory(folderPath);
    string userFilename = Path.Combine(folderPath, username + "SampleRecord.txt");
    System.IO.File.Create(userFilename);
    File.WriteAllText(userFilename, SampleCaseText);
