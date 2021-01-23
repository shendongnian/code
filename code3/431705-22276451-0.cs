        bool painted = false
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
            if (painted) return;
            e.Graphics.DrawImage(BackgroundImage, new System.Drawing.Point(0, 0));
            painted = true;
        }
