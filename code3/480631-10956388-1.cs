    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Drawing.Imaging;
    
    class MetronomeControl : Control
    {
        private Bitmap hand;
        private float angle = 0;
        private float direction = 5;
        private Timer timer = new Timer { Enabled = true, Interval = 100 };
    
        public MetronomeControl()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint, true);
            hand = CreateCrappyHandBitmap();
            timer.Tick += new EventHandler(timer_Tick);
        }
    
        void timer_Tick(object sender, EventArgs e)
        {
            if (angle < -45 || angle > 45)
                direction = -direction;
            angle += direction;
            Invalidate();
        }
    
        private static Bitmap CreateCrappyHandBitmap()
        {
            Bitmap bitmap = new Bitmap(60, 200, PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.Transparent);
                graphics.FillRectangle(Brushes.Bisque, 30 - 10, 0, 20, 200);
                graphics.FillPolygon(Brushes.IndianRed, new Point[] { new Point(30 - 30, 40), new Point(30 + 30, 40), new Point(30 + 20, 80), new Point(30 - 20, 80) });
            }
            return bitmap;
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            // Erase background since we specified AllPaintingInWmPaint
            e.Graphics.Clear(Color.White);
    
            // Move the 0,0 point to the bottom-center of our client area
            e.Graphics.TranslateTransform(ClientSize.Width / 2, ClientSize.Height);
            // Rotate around this new 0,0
            e.Graphics.RotateTransform(angle);
            // Draw the image so that the bottom-center of the image is 0,0 (might look better to move this down off screen)
            e.Graphics.DrawImage(hand, 0 - hand.Width / 2, 0 - hand.Height);
    
            // Reset the transform for other drawing
            e.Graphics.ResetTransform();
    
            base.OnPaint(e);
        }
    }
    
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form { Controls = { new MetronomeControl { Dock = DockStyle.Fill } } });
        }
    }
