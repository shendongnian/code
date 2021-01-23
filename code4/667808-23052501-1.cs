    private const string DropBoxUsername = "abc@hotmail.com";
    private const string DropBoxPassword = "password";
    private const string FolderName = "MainFolder";
    private const string UserEmail = "abc@hotmail.com";
    protected void BtnUploadClick(object sender, EventArgs e)
    {
       var client = new SkyDriveServiceClient();
       // log on into drop box using username and password
       client.LogOn(DropBoxUsername, DropBoxPassword);
       // verifying the company folder is available or not
       WebFolderInfo userskyDrivefolder = null;
       WebFolderInfo clientskyDrivefolder = 
       client.ListRootWebFolders().FirstOrDefault(subWebFolder => subWebFolder.Name == FolderName);
        if (clientskyDrivefolder != null)
        {
            foreach (WebFolderInfo subWebFolder in client.ListSubWebFolders(clientskyDrivefolder))
            {
                if (subWebFolder.Name == UserEmail)
                {
                    userskyDrivefolder = subWebFolder;
                    break;
                }
            }
        }
    }
