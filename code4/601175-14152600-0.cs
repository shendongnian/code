        var blobClient = account.CreateCloudBlobClient();
        // Upload picture.
        var picturesContainer = blobClient.GetContainerReference("pictures");
        picturesContainer.CreateIfNotExists();
        var myPictureBlob = picturesContainer.GetBlockBlobReference("me.png");
        using (var fs = new FileStream(@"C:\Users\Public\Pictures\Sample Pictures\Chrysanthemum.jpg", FileMode.Open))
            myPictureBlob.UploadFromStream(fs);
        // Backup picture.
        var backupContainer = blobClient.GetContainerReference("backup");
        backupContainer.CreateIfNotExists();
        var backupBlob = picturesContainer.GetBlockBlobReference("me.png");
            
        var task = Task.Factory.FromAsync<string>(backupBlob.BeginStartCopyFromBlob(myPictureBlob, null, null), backupBlob.EndStartCopyFromBlob);
        task.ContinueWith((t) =>
        {
            if (!t.IsFaulted)
            {
                while (true)
                {
                    Console.WriteLine("Copy state for {0}: {1}", backupBlob.Uri, backupBlob.CopyState.Status);
                    Thread.Sleep(500);
                }
            }
            else
            {
                Console.WriteLine("Error: " + t.Exception);
            }
        });
