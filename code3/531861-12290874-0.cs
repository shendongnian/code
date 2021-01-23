    using System.Windows.Media.Imaging;
    using System.Windows.Resources;
    BitmapImage bmp = new BitmapImage();
    Uri uri = new Uri("/SilverlightApp1;component/Resources/foto.jpg", UriKind.Relative);
    StreamResourceInfo sri = Application.GetResourceStream(uri);
    bmp.SetSource(sri.Stream);
    Image image = new Image();
    image.Source = bmp;
    
