        public byte[] ImageToBytes(BitmapImage imgSource)
        {
            MemoryStream objMS = new MemoryStream();        
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imgSource));
            encoder.Save(objMS);
            return objMS.GetBuffer();
        }
