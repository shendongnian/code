        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var r = new RectangleEx(this.ClientRectangle);
            var path = RoundRectanglePath.Create(r.ToRectangle(), this.Radius, this.Corners);
            this.Region = new Region(path);
        }
