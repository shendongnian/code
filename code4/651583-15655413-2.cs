    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;
    internal class FadeControl : Control
    {
        private int opacity = 100;
        private Bitmap backgroundBuffer;
        private bool skipPaint;
        public FadeControl()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.DoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);
        }
        public int Opacity
        {
            get
            {
                return opacity;
            }
            set
            {
                if (value > 100) opacity = 100;
                else if (value < 1) opacity = 1;
                else opacity = value;
                if (Parent != null)
                    Parent.Invalidate(Bounds, true);
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //do nothig
        }
        protected override void OnMove(EventArgs e)
        {
            RecreateHandle();
        }
        private void CreateBackgroundBuffer(Control parent)
        {
            int offsetX;
            int offsetY;
            GetOffsets(out offsetX, out offsetY, parent);
            backgroundBuffer = new Bitmap(Width + offsetX, Height + offsetY);
        }
        protected override void OnResize(EventArgs e)
        {
            var parent = Parent;
            if (parent != null)
            {
                CreateBackgroundBuffer(parent);
            }
            base.OnResize(e);
        }
        private void GetOffsets(out int offsetX, out int offsetY, Control parent)
        {
            var parentPosition = parent.PointToScreen(Point.Empty);
            offsetY = Top + parentPosition.Y - parent.Top;
            offsetX = Left + parentPosition.X - parent.Left;
        }
        private void UpdateBackgroundBuffer(int offsetX, int offsetY, Control parent)
        {
            if (backgroundBuffer == null)
            {
                CreateBackgroundBuffer(parent);
            }
            Rectangle parentBounds = new Rectangle(0, 0, Width + offsetX, Height + offsetY);
            skipPaint = true;
            parent.DrawToBitmap(backgroundBuffer, parentBounds);
            skipPaint = false;
        }
        private void DrawBackground(Graphics graphics, Rectangle bounds)
        {
            int offsetX;
            int offsetY;
            var parent = Parent;
            GetOffsets(out offsetX, out offsetY, parent);
            UpdateBackgroundBuffer(offsetX, offsetY, parent);
            graphics.DrawImage(backgroundBuffer, bounds, offsetX, offsetY, Width, Height, GraphicsUnit.Pixel);
        }
        private void Draw(Graphics graphics)
        {
            Rectangle bounds = new Rectangle(0, 0, Width, Height);
            DrawBackground(graphics, bounds);
            int alpha = (opacity * 255) / 100;
            using (Brush bckColor = new SolidBrush(Color.FromArgb(alpha, BackColor)))
            {
                if (BackColor != Color.Transparent)
                {
                    graphics.FillRectangle(bckColor, bounds);
                }
            }
            ColorMatrix colorMatrix = new ColorMatrix();
            colorMatrix.Matrix33 = (float)alpha / 255;
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            if (BackgroundImage != null)
            {
                graphics.DrawImage(BackgroundImage, bounds, 0, 0, Width, Height, GraphicsUnit.Pixel, imageAttr);
            }
            if (Text != string.Empty)
            {
                using (Brush txtBrush = new SolidBrush(Color.FromArgb(alpha, ForeColor)))
                {
                    graphics.DrawString(Text, Font, txtBrush, 5, 5);
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!skipPaint)
            {
                Graphics graphics = e.Graphics;
                Draw(graphics);
            }
        }
        protected override void OnBackColorChanged(EventArgs e)
        {
            if (Parent != null)
            {
                Parent.Invalidate(Bounds, true);
            }
            base.OnBackColorChanged(e);
        }
        protected override void OnParentBackColorChanged(EventArgs e)
        {
            Invalidate();
            base.OnParentBackColorChanged(e);
        }
    }
