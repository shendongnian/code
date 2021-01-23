    using System;
    using System.Drawing;   // NOTE: add reference!!
    
    class Program {
        static void Main(string[] args) {
            using (var bmp = new Bitmap(100, 100))
            using (var gr = Graphics.FromImage(bmp)) {
                gr.FillRectangle(Brushes.Orange, new Rectangle(0, 0, bmp.Width, bmp.Height));
                var path = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "Example.png");
                bmp.Save(path);
            }
        }
    }
