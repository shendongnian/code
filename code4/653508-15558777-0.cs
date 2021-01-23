        public bool IsEqual(BitmapImage image1, BitmapImage image2)
        {
            byte[] data1;
            byte[] data2;
            var encoder = new BmpBitmapEncoder();
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Frames.Add(BitmapFrame.Create(image1));
                encoder.Save(ms);
                data1 = ms.ToArray();
            }
            encoder = new BmpBitmapEncoder();
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Frames.Add(BitmapFrame.Create(image2));
                encoder.Save(ms);
                data2 = ms.ToArray();
            }
            return data1 == null || data2 == null ? false : data1.SequenceEqual(data2);
        }
