    private void DisposeImage(BitmapImage image)
    {
        if (image != null)
        {
            try
            {
                using (var ms = new MemoryStream(new byte[] { 0x0 }))
                {
                    image.SetSource(ms);
                }
            }
            catch (Exception)
            {
            }
        }
    }
