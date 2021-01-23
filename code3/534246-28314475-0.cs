    private async Task<BitmapImage> ByteArrayToBitmapImage(byte[] byteArray)
        {
            BitmapImage image = new BitmapImage();
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes((byte[])byteArray);
                    writer.StoreAsync().GetResults();
                }
                image.SetSource(stream);
            }
            image.DecodePixelHeight = 250;
            image.DecodePixelWidth = 250;
            return image;            
        }
