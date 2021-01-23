        public RoundRectangle()
        {
            this.ResizeRedraw = true;
            this.VisibleChanged += new EventHandler(RoundRectangle_VisibleChanged);
        }
        private bool RegionSet = false;
        void RoundRectangle_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && !RegionSet)
            {
                RegionSet = true;
                var r = new RectangleEx(this.ClientRectangle);
                var path = RoundRectanglePath.Create(r.ToRectangle(), this.Radius, this.Corners);
                this.Region = new Region(path);
            }
        }
