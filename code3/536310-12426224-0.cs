    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode=SmoothingMode.AntiAlias;
            DrawPipe(e.Graphics, 10f, new PointF(10, 10), new PointF(250, 80), Color.White, Color.Black);
            DrawPipe(e.Graphics, 10f, new PointF(15, 60), new PointF(280, 120), Color.BlueViolet, Color.Black);
        }
        private void DrawPipe(Graphics g, float width, PointF p1, PointF p2, Color mid_color, Color edge_color)
        {
            SizeF along=new SizeF(p2.X-p1.X, p2.Y-p1.Y);
            float mag=(float)Math.Sqrt(along.Width*along.Width+along.Height*along.Height);
            along=new SizeF(along.Width/mag, along.Height/mag);
            SizeF perp=new SizeF(-along.Height, along.Width);
            PointF p1L=new PointF(p1.X+width/2*perp.Width, p1.Y+width/2*perp.Height);
            PointF p1R=new PointF(p1.X-width/2*perp.Width, p1.Y-width/2*perp.Height);
            PointF p2L=new PointF(p2.X+width/2*perp.Width, p2.Y+width/2*perp.Height);
            PointF p2R=new PointF(p2.X-width/2*perp.Width, p2.Y-width/2*perp.Height);
            GraphicsPath gp=new GraphicsPath();
            gp.AddLines(new PointF[] { p1L, p2L, p2R, p1R});
            gp.CloseFigure();
            Region region=new Region(gp);
            using(LinearGradientBrush brush=new LinearGradientBrush(
                p1L, p1R, Color.Black, Color.Black))
            {
                ColorBlend color_blend=new ColorBlend();
                color_blend.Colors=new Color[] { edge_color, mid_color, edge_color };
                color_blend.Positions=new float[] { 0f, 0.5f, 1f };
                brush.InterpolationColors=color_blend;
                g.FillRegion(brush, region);
            }
        }
    }
