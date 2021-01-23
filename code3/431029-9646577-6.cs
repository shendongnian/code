    public partial class CustomProgressBar : UserControl
    {
        public int Percentage { get; set; }
        public CustomProgressBar()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle bounds = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            // Paint a green bar indicating the progress.
            g.FillRectangle
            (
                Brushes.LimeGreen,
                new Rectangle
                (
                    bounds.X,
                    bounds.Y,
                    (int)(bounds.Width * Percentage / 100.0),
                    bounds.Height
                )
            );
            // Draw a black frame around the progress bar.
            g.DrawRectangle(Pens.Black, bounds);
            
            // Draw the percentage label.
            TextRenderer.DrawText(g, Percentage + "%", Font, bounds, ForeColor);
        }
    }
