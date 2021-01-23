    class Program
    {
        static void Main(string[] args)
        {
            Bitmap bmp1 = new Bitmap("C:/donut.jpg");
            bmp1.Save("c:\\button.gif", System.Drawing.Imaging.ImageFormat.Gif);
            Console.WriteLine("Save Success");
            Console.Read();
        }
    }
