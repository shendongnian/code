    public PhotoImageSource GetImage()
    {
        string filename = "c:\Images\myimage.png";
        var image = new BitmapImage();
        using (var stream = new FileStream(fileName, FileMode.Open))
        {
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = stream;
            image.EndInit();
        }
        image.Freeze(); //prevent error "Must create DependencySource on same Thread as the DependencyObject"
        return new PhotoImageSource(image, filename);
    }
    public class PhotoImageSource
    {
        public PhotoImageSource(ImageSource image, string filename)
        {
            Image = image;
            Filename = filename;
        }
        public ImageSource Image { get; set; }
        public string Filename { get; set; }
    }
