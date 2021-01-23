    public class CustomImageTooltip : CustomTooltip
    {
         public Image Image
         {
            get
            {
                if (Tag is Image)
                    return Tag as Image;
                else
                    return null;
            }
         }
        public CustomImageTooltip()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
        }
        public void Subscribe(Control control, Image image)
        {
            base.Subscribe(control, image);
        }
        public void Subscribe(ITooltipTarget item, Image image)
        {
            base.Subscribe(item, image);
        }
        protected override void OnTagChanged(EventArgs e)
        {
            base.OnTagChanged(e);
            if (Image != null)
                this.Size = Image.Size;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            if (Image != null)
                g.DrawImage(
                    Image,
                    new RectangleF(0, 0, ClientSize.Width, ClientSize.Height),
                    new RectangleF(0, 0, Image.Size.Width, Image.Size.Height),
                    GraphicsUnit.Pixel
                );
            g.DrawRectangle(Pens.Black, 0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
        }
    }
