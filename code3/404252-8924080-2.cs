    public class ImageResult : ActionResult
    {
        private readonly string _agha;
        public ImageResult(string agha)
        {
            _agha = agha;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            Color BackColor = Color.White;
            String FontName = "Times New Roman";
            int FontSize = 25;
            int Height = 50;
            int Width = 700;
            using (Bitmap bitmap = new Bitmap(Width, Height))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Color color = Color.Gray;
                Font font = new Font(FontName, FontSize);
                SolidBrush BrushBackColor = new SolidBrush(BackColor);
                Pen BorderPen = new Pen(color);
                Rectangle displayRectangle = new Rectangle(new Point(0, 0), new Size(Width - 1, Height - 1));
                graphics.FillRectangle(BrushBackColor, displayRectangle);
                graphics.DrawRectangle(BorderPen, displayRectangle);
                graphics.DrawString(_agha, font, Brushes.Red, 20, 20);
                context.HttpContext.Response.ContentType = "image/jpg";
                bitmap.Save(context.HttpContext.Response.OutputStream, ImageFormat.Jpeg);
            }
        }
    }
