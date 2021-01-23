     byte[] stream = File.ReadAllBytes(@"D:\YWG\123.jpg");
                using (MemoryStream MS = new MemoryStream(stream, 0, stream.Length))
                {
                    MS.Write(stream, 0, stream.Length);
    
                    using (Image img = Image.FromStream(MS))
                    {
                        img.Save(@"D:\dd.jpg", System.Drawing.Imaging.ImageFormat.Gif);
                    } 
                }
