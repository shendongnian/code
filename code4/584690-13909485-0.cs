Uri uri = new Uri("/image.jpg", UriKind.Relative);
BitmapImage bitmapImage = new BitmapImage();
bitmapImage.CreateOptions = BitmapCreateOptions.None;
bitmapImage.UriSource = uri;
WriteableBitmap img = new WriteableBitmap(bitmapImage);
using (MemoryStream ms = new MemoryStream())
{
    // write an image into the stream
    Extensions.SaveJpeg(img, ms, img.PixelWidth, img.PixelHeight, 0, 100);
    byte[] byteArray = ms.ToArray();
}
