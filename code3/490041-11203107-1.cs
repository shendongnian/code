        static void Main(string[] args)
        {
            MemoryStream ms = new MemoryStream();
            using(FileStream fs = new FileStream(@"I:\tmp.jpg", FileMode.Open))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                ms.Write(buffer, 0, buffer.Length);
            }
            Bitmap bitmap = new Bitmap(ms);
            
            // do stuff
            bitmap.Save(@"I:\tmp.jpg");
        }
