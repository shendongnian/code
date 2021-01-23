    static void Main(string[] args)
    {
        byte[] data = new WebClient().DownloadData("http://srv2.jpg.co.il/1/51c616787a3fa.png");
        Image image = Image.FromStream(new MemoryStream(data));
        LockBitmap bitmap = new LockBitmap(new Bitmap(image));
        // this essentially copies the data into memory and copies from a pointer to an array
        bitmap.LockBits();
        Color black = Color.FromArgb(0, 0, 0);
        Color white = Color.FromArgb(255, 255, 255);
        Stopwatch stopwatch = Stopwatch.StartNew();
        for (int y = 0; y < bitmap.Height; y++)
        {
            for (int x = 0; x < bitmap.Width; x++)
            {
                // GetPixel is a nice abstraction the author in the Article created so we don't have to do any of the gritty stuff.
                if (bitmap.GetPixel(x, y) == black)
                {
                    if (bitmap.GetPixel(x + 8, y) == black && bitmap.GetPixel(x + 8, y + 3) == white)
                    {
                        Console.WriteLine("White Ball Found in {0}", stopwatch.Elapsed.ToString());
                        break;
                    }
                }
            }
        }
            
        bitmap.UnlockBits(); // copies the data from the array back to the original pointer
            
        Console.Read();
    }
