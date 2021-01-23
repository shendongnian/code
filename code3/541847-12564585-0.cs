    public List<Image> GetAllFrames(Stream sm)
            {
                List<Image> images = new List<Image>();
                Bitmap bitmap = new Bitmap(sm);
                int count = bitmap.GetFrameCount(FrameDimension.Page);
                for (int idx = 0; idx < count; idx++)
                {
                    bitmap.SelectActiveFrame(FrameDimension.Page, idx);
                    MemoryStream byteStream = new MemoryStream();
                    bitmap.Save(byteStream, ImageFormat.Tiff);
    
                    images.Add(Image.FromStream(byteStream));
                }
                return images;
            }
