    private async void CreateThumbnailButton_Clicked(object sender, EventArgs args)
        {
            SynchronizationContext uiThread = SynchronizationContext.Current;
            var result = await Task.Factory.StartNew<WriteableBitmap>(() =>
                {
                    Stream img = GetOriginalImage();// get the original image through a long synchronous operation
                    return CreateThumbnail(img, 163, 163, uiThread);
                });
            await SaveThumbnailAsync(result);
        }
