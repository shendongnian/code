        public class ToolStripImageButton: ToolStripButton
    {
        public ToolStripImageButton()
            : base()
        {
        }
        private Image iconMap;
        private Int32 iconMapIndex;
        [RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public Image IconMap
        {
            get { return this.iconMap; }
            set
            {
                this.iconMap = value;
                this.RecalculateImage();
            }
        }
        [RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public Int32 IconMapIndex
        {
            get { return this.iconMapIndex; }
            set
            {
                this.iconMapIndex = value;
                this.RecalculateImage();
            }
        }
        protected void RecalculateImage()
        {
            if (base.Image != null)
            {
                base.Image.Dispose();
                base.Image = null;
            }
            if (this.iconMap != null)
            {
                // assumes each icon is 16x16, you could add more properties for flexibility
                Int32 x = this.iconMap.Width / 16;
                Int32 y = this.iconMap.Width / 16;
                Int32 iconCount = x * y;
                if (this.iconMapIndex < 0 || this.iconMapIndex >= iconCount) return;
                Int32 offsetX = (this.iconMapIndex % x) * 16;
                Int32 offsetY = (this.iconMapIndex / x) * 16;
                Bitmap bitmap = new Bitmap(16, 16);
                using (Graphics g = Graphics.FromImage(bitmap))
                g.DrawImage(
                    this.iconMap,
                    new Rectangle(0,0,bitmap.Width,bitmap.Height), 
                    new Rectangle(offsetX, offsetY, bitmap.Width, bitmap.Height), 
                        GraphicsUnit.Pixel);
                base.Image = bitmap;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image Image
        {
            get
            {
                return base.Image;
            }
            set
            {
                // ignore
            }
        }
