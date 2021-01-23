        private static BitmapImage ByStream(FileInfo info)
        {   //http://social.msdn.microsoft.com/Forums/en-US/wpf/thread/dee7cb68-aca3-402b-b159-2de933f933f1
            try
            {
                if (info.Exists)
                {
                    // do this so that the image file can be moved in the file system
                    BitmapImage result = new BitmapImage();
                    // Create new BitmapImage   
                    Stream stream = new MemoryStream(); // Create new MemoryStream   
                    Bitmap bitmap = new Bitmap(info.FullName);
                    // Create new Bitmap (System.Drawing.Bitmap) from the existing image file 
                                                 (albumArtSource set to its path name)   
                    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    // Save the loaded Bitmap into the MemoryStream - Png format was the only one I 
                                  tried that didn't cause an error (tried Jpg, Bmp, MemoryBmp)   
                    bitmap.Dispose(); // Dispose bitmap so it releases the source image file   
                    result.BeginInit(); // Begin the BitmapImage's initialisation   
                    result.StreamSource = stream;
                    // Set the BitmapImage's StreamSource to the MemoryStream containing the image   
                    result.EndInit(); // End the BitmapImage's initialisation   
                    return result; // Finally, set the WPF Image component's source to the 
                                    BitmapImage  
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
