        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                rec.Width = e.X - rec.X;
                rec.Height = e.Y - rec.Y;
                this.Invalidate();
            }
            if (e.Button == MouseButtons.Right)
            {
                rec.Location = new Point((e.X-MouseDownLocation.X) + rec.Left, (e.Y-MouseDownLocation.Y) + rec.Top);
                MouseDownLocation = e.Location;
                this.Invalidate();
            }
        }
