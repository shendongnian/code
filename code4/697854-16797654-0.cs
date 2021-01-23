    public async StorageFile PickImage()
    {
        FileOpenPicker ImagePicker = new FileOpenPicker();
        ...
        StorageFile file = await ImagePicker.PickSingleFileAsync(); // 
        ...
        return file;
    }
    private async void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        ...
        StorageFile copyImage = await this.PickImage().CopyAsync(DateTimeFolder, "image", NameCollisionOption.ReplaceExisting);
        ...
    }
