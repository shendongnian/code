    public async StorageFile PickImage()
    {
        FileOpenPicker ImagePicker = new FileOpenPicker();
        ...
        return await ImagePicker.PickSingleFileAsync(); // 
        ...
    }
    
    
    private async void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        StorageFile pickedFile = await PickImage();
        StorageFile copyImage = await file.CopyAsync(DateTimeFolder, "image", NameCollisionOption.ReplaceExisting);
        ...
    }
