    private void Screenshot(FrameworkElement element, String fileNameLoader)
    {
        WriteableBitmap bmp = new WriteableBitmap(element, null);
        using (MemoryStream ms = new MemoryStream())
        {
            bmp.SaveJpeg(ms, (int)element.ActualWidth, (int)element.ActualHeight, 0, 100);
            ms.Seek(0, SeekOrigin.Begin);
            using (MediaLibrary lib = new MediaLibrary())
            {
                String filePath = string.Format(fileNameLoader);
                lib.SavePicture(filePath, ms);
            }
        }
    }
