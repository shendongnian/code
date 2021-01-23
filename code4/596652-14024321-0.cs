        public WriteableBitmap Picture
        {
            get
            {
                using (var memoryStream = new MemoryStream(PicBytes))
                {
                    return PictureDecoder.DecodeJpeg(memoryStream);
                }
            }
        }
