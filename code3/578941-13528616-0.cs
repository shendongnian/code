        private bool drawMessage;
        private void Refresh_Click(object sender, EventArgs e) {
            drawMessage = !drawMessage;
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e) {
            if (drawMessage) {
                TextRenderer.DrawText(e.Graphics, "You clicked Refresh", this.Font, Point.Empty, this.ForeColor);
            }
            base.OnPaint(e);
        }
