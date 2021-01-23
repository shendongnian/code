            public static BitmapImage LoadImage(byte[] bytes)
            {
                var memoryStream = new MemoryStream(bytes);
                
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.EndInit();
                return bitmapImage;              
            }
    
            public static void CreateTiff(string destPath, params string[] filePaths)
            {
                using (FileStream fs = new FileStream(destPath, FileMode.Append, 
                                                                FileAccess.Write))
                {
                    var tifEnc = new TiffBitmapEncoder();
                    tifEnc.Compression = TiffCompressOption.Default;
    
                    foreach (string fileName in filePaths)
                    {
                        var image = LoadImage(File.ReadAllBytes(fileName));
                      
                        tifEnc.Frames.Add(BitmapFrame.Create(image));
                    }
    
                    tifEnc.Save(fs);
                }
    
            }
