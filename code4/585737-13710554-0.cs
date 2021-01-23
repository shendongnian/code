    public partial class DrawImageDemo : Form
    {
        public DrawImageDemo()
        {
            InitializeComponent();
        }
    
        private Image _sprites;
        public Image Sprites
        {
            get
            {
                if (_sprites == null)
                {
                    _sprites = Image.FromFile("test.jpg");
                }
                return _sprites;
            }
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            // The forms graphics object
            Graphics g = e.Graphics;
    
            // Portion of original image to display
            Rectangle region = new Rectangle(0, 0, 80, 80);
    
            g.DrawImage(Sprites, 25, 25, region, GraphicsUnit.Pixel);
    
            base.OnPaint(e);
        }
            
    }
