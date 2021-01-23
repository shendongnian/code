    WriteableBitmap wmp;
                wmp = cis.Bitmap;
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(wmp));
                string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"Image 1.png");
                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        encoder.Save(fs);
                    }
                }
                catch (IOException ioe)
                {
                    Console.WriteLine(ioe.ToString());
                }
                return path;
