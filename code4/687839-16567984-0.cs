    BitmapImage image = new BitmapImage();
    image.SetSource(fileStream);
    
    WriteableBitmap bitmap = new WriteableBitmap(image);
    WriteableBitmap resizedBitmap = bitmap.Resize(25, 25, WriteableBitmapExtensions.Interpolation.Bilinear);
    
    CurrentOrder.CompanyImage = resizedBitmap.ToByteArray();
