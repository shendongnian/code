    private async void Save_Image(MemoryStream image)
        {
            // Launch file picker
            FileSavePicker picker = new FileSavePicker();
            picker.FileTypeChoices.Add("JPeg", new List<string>() { ".jpg", ".jpeg" });
            StorageFile file = await picker.PickSaveFileAsync();            
            if (file == null)
                return;
            using (Stream x = await file.OpenStreamForWriteAsync())
            {
                x.Seek(0, SeekOrigin.Begin);
                image.WriteTo(x);
            }
            
        }
