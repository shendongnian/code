    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;
    
    class MetronomeControl : Control
    {
        private Bitmap hand;
        private float angle = 0;
        private float direction = 2;
        private Timer timer = new Timer { Enabled = true, Interval = 30 };
    
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
            Bitmap bitmap = new Bitmap(100, 300, PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.Transparent);
                graphics.FillRectangle(Brushes.LightGray, 50 - 5, 0, 10, 300);
                graphics.FillPolygon(Brushes.LightSlateGray, new Point[] { new Point(50 - 30, 40), new Point(50 + 30, 40), new Point(50 + 20, 80), new Point(50 - 20, 80) });
                graphics.FillEllipse(Brushes.LightSlateGray, 0, 200, 100, 100);
            }
            return bitmap;
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            // Erase background since we specified AllPaintingInWmPaint
            e.Graphics.Clear(Color.AliceBlue);
    
            e.Graphics.DrawString(Text, Font, Brushes.Black, new RectangleF(0, 0, ClientSize.Width, ClientSize.Height), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
    
            // Move the 0,0 point to the just below the bottom-center of our client area
            e.Graphics.TranslateTransform(ClientSize.Width / 2, ClientSize.Height + 40);
            // Rotate around this new 0,0
            e.Graphics.RotateTransform(angle);
            // Turn on AA to make it a bit less jagged looking
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            // Draw the image so that the center of the ellipse is at 0,0
            e.Graphics.DrawImage(hand, 0 - hand.Width / 2, 0 - hand.Height + 50);
    
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
            Application.Run(new Form
            {
                Text = "Metronome Control Demo",
                ClientSize = new Size(640, 480),
                Controls =
                {
                    new MetronomeControl
                    {
                        Location = new Point(10, 10),
                        Size = new Size (340, 300),
                        Font = new Font(FontFamily.GenericSansSerif, 24),
                        Text = "Metronome Control Demo",
                    }
                }
            });
        }
    }
