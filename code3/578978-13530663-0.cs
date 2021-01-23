        public async Task<BitmapImage> GetImage(string value)
        {
            if (value == null)
                return null;
            var buffer = System.Convert.FromBase64String(value);
            using (InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(ms.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(buffer);
                    await writer.StoreAsync();
                }
                var image = new BitmapImage();
                image.SetSource(ms);
                return image;
            }
        }
