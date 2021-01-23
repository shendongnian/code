        private Point oldLocation = new Point(int.MaxValue, 0);
        protected override void OnLocationChanged(EventArgs e) {
            if (oldLocation.X != int.MaxValue && this.Owner != null) {
                this.Owner.Location = new Point(
                    this.Owner.Left + this.Left - oldLocation.X,
                    this.Owner.Top + this.Top - oldLocation.Y);
            }
            oldLocation = this.Location;
            base.OnLocationChanged(e);
        }
