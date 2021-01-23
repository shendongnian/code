    private int myFlipView_SelectionChangedCallId;
    async private void myFlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (myFlipView == null) return;
        var callId = ++myFlipView_SelectionChangedCallId;
        Uri newUri = new Uri("ms-appx://" + (((BitmapImage)(((Image)(((ContentControl)(myFlipView.SelectedItem)).Content)).Source)).UriSource.AbsolutePath));
        StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(newUri);
        if (callId != myFlipView_SelectionChangedCallId) return;
        WriteableBitmap wb = new WriteableBitmap(1, 1);
        if (file != null)
        {
            using (IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
            {
                await wb.SetSourceAsync(fileStream);
                if (callId != myFlipView_SelectionChangedCallId) return;
            }
        }
        wb = ModifyPicture(wb);
        myImage.Source = wb;
    }
