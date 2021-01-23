    static void Main(string[] args)
        {
            string file = @"C:\Users\Public\Pictures\delme.jpg";
            byte[] data = File.ReadAllBytes(file);
            using (MemoryStream originalms = new MemoryStream(data))
            {
                using (Image i = Image.FromStream(originalms))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Throws ExternalException on Windows 7, not Windows XP                        
                        //bf.Serialize(ms, i);
                        i.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp); // Works
                        i.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Works
                        i.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Fails
                    }
                }
            }
        }
