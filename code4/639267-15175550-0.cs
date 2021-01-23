    static void Main(string[] args) {
        int width = 512;
        int height = 512;
        int x, y, w, h;
        x = y = 10;
        w = h = 100;
        using (Bitmap bmp = new Bitmap(width, height)) {
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.FillRectangle(
                    brush: new SolidBrush(
                        color: Color.Blue
                    ),
                    rect: new Rectangle(x, y, w, h)
                );
                g.DrawRectangle(
                    pen: new Pen(
                        color: Color.Black, 
                        width: 3
                    ),
                    rect: new Rectangle(x, y, w, h)
                );
                bmp.Save(@"D:\result.png", ImageFormat.Png);
            }
        }
    }
