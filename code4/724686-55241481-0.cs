         using ImageMagick;
         public void PDFToBMP(string output)
         {
            MagickReadSettings settings = new MagickReadSettings();
            // Settings the density to 500 dpi will create an image with a better quality
            settings.Density = new Density(500);
            string[] files= GetFiles();
            foreach (string file in files)
            {
                string fichwithout = Path.GetFileNameWithoutExtension(file);
                string path = Path.Combine(output, fichwithout);
                using (MagickImageCollection images = new MagickImageCollection())
                {
                    images.Read(fich);
                    foreach (MagickImage image in images)
                    {
                        settings.Height = image.Height;
                        settings.Width = image.Width;
                        image.Format = MagickFormat.Bmp; //if you want to do other formats of image, just change the extension here! 
                        image.Write(path + ".bmp"); //and here!
                    }
                }
            }
        }
