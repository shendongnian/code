    private async void btnBrowsePhotos_Click(object sender, RoutedEventArgs e)
    {
        FileOpenPicker openPicker = new FileOpenPicker();
    
        openPicker.ViewMode = PickerViewMode.Thumbnail;
        openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
        openPicker.FileTypeFilter.Add(".jpg");
        openPicker.FileTypeFilter.Add(".jpeg");
        openPicker.FileTypeFilter.Add(".png");
    
        var files = await openPicker.PickMultipleFilesAsync();
        List<ImageItem> ImageList = new List<ImageItem>();
        foreach (var file in files)
        {
            using (var stream = await file.OpenAsync(FileAccessMode.Read))
            {
                ImageList.Add(new ImageItem(stream, file.Name)); 
            }
        }
    
        gv.ItemsSource = ImageList;
    }
    public class ImageItem
    {
        public BitmapImage Source { get; set; }
        public string Name { get; set; }
    
        public ImageItem(IRandomAccessStream stream, string name)
        {
            BitmapImage bmp = new BitmapImage();
            bmp.SetSource(stream);
            Source = bmp;
            Name = name;
        }
    }
