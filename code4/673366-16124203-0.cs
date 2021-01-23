    StorageFile storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync(SelectFile);
    XDocument document = XDocument.Load(storageFile.Path);
    var elementStepOne = document.Elements("StepOne").Single();
    elementStepOne.Value = "delete content";
    var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(
        SelectFile, 
        CreationCollisionOption.ReplaceExisting);
    using (var writeStream = await file.OpenStreamForWriteAsync())
    {
        document.Save(writeStream);
    }
