            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                this.textBlock.Text = 
                    "File Path: " + file.Path + Environment.NewLine + 
                    "File Name: " + file.Name;
                try
                {
                    var stream = await file.OpenReadAsync();
                    var imageSource = new BitmapImage();
                    await imageSource.SetSourceAsync(stream);
                    this.image.Source = imageSource;
                }
                catch (Exception ex)
                {
                    this.textBlock.Text = ex.ToString();
                }
            }
            else
            {
                this.textBlock.Text = "Operation cancelled.";
            }
