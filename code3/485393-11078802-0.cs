      private BitmapSource ConvertPic(Stream Image)
            {
                BitmapSource ContactImage;
                if (Image == null)
                {
                    return ContactImage = null;
                }
                var bmp = new BitmapImage();
                bmp.SetSource(Image);
                ContactImage = bmp;
                return ContactImage;
            }
