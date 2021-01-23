    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    
    namespace ByteTransformer
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var fs = File.OpenRead("byteArray.dat"))
                {
                    var bm = Image.FromStream(fs);
    
                    using (MemoryStream msJpg = new MemoryStream())
                    {
                        bm.Save(msJpg, ImageFormat.Jpeg);
                        using (var ts = File.Create("out.jpg"))
                        {
                            var img = msJpg.ToArray();
                            ts.Write(img, 0, img.Length);
                        }
                    }
                }
            }
        }
    }
