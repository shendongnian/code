    static void Main(string[] args)
    {
        Bitmap arie = new Bitmap(@"C:\Users\User\Desktop\letter.bmp");
        object [,] arr = new object[arie.Width, arie.Height];
        int min=1000,counter=1;
        for (int i = 0; i < arie.Width; i++)
        {
            for (int j = 0; j < arie.Height; j++)
            {
                if (arie.GetPixel(i, j).ToArgb() == Color.White.ToArgb())
                {
                    arr[i, j] = 0;
                }
                else
                    arr[i, j] = 1;
            }
        }
        for (int y = 0; y < arie.Height; y++)
        {
           for (int x = 0; x < arie.Width; x++)
           {
               Console.Write(arr[x, y]);
           }
           Console.WriteLine();
        }
    }
