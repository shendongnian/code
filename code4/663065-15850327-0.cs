    public static async System.Threading.Tasks.Task DownloadUserImage(SQLUser userData)
    {
        var usersFolder = await GetUsersFolder();
        var imageUri = new Uri(userData.ImageUri);
        var accountName = "<SNIP>";
        var key = "<SNIP>";
        StorageCredentials cred = new StorageCredentials(accountName, key);
        CloudBlobClient client = new CloudBlobClient(new Uri(string.Format("https://{0}", imageUri.Host)), cred);
        CloudBlobContainer container = client.GetContainerReference(userData.ContainerName);
        var blob = await container.GetBlobReferenceFromServerAsync(userData.ResourceName);
        var imageFile = await usersFolder.CreateFileAsync(userData.Id.ToString() + ".jpg", CreationCollisionOption.ReplaceExisting);
        using (var fileStream = await imageFile.OpenStreamForWriteAsync())
        {
            try
            {
                await blob.DownloadToStreamAsync(fileStream.AsOutputStream());
            }
            catch (Exception e)
            {
                Tools.HandleLiveException(e);
            }
        }
    }
