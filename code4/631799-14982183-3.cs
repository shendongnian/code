    blobClient = new CloudBlobClient(
        blobstoreurl, new StorageCredentialsSharedAccessSignature(signature));
    container = blobClient.GetContainerReference(containerName);
    CloudBlobDirectory dir = 
        container.GetDirectoryReference(comboBoxCameras.SelectedItem.ToString());
    CloudBlob cloudBlob = dir.GetBlobReference(
        comboBoxCameras.SelectedItem.ToString().Replace(" ","") + ".txt");
    pictureBoxLiveViewer.ImageLocation = cloudBlob.DownloadText() + signature;
