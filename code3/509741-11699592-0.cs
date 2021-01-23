    class Program
    {
        public static void Main(string[] args)
        {
            const int dotsPerInch = 600;    // define the quality in DPI
            const double widthInInch = 6;   // width of the bitmap in INCH
            const double heightInInch = 1;  // height of the bitmap in INCH
            using (Bitmap bitmap = new Bitmap((int)(widthInInch * dotsPerInch), (int)(heightInInch * dotsPerInch)))
            {
                bitmap.SetResolution(dotsPerInch, dotsPerInch);
                using (Font font = new Font(FontFamily.GenericSansSerif, 0.8f, FontStyle.Bold, GraphicsUnit.Inch))
                using (Brush brush = Brushes.Black)
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.White);
                    graphics.DrawString("Wow, I can C#", font, brush, 2, 2);
                }
                // Save the bitmap
                bitmap.Save("n:\\test.bmp");
                // Print the bitmap
                using (PrintDocument printDocument = new PrintDocument())
                {
                    printDocument.PrintPage += (object sender, PrintPageEventArgs e) =>
                    {
                        e.Graphics.DrawImage(bitmap, 0, 0);
                    };
                    printDocument.Print();
                }
            }
        }
    }
