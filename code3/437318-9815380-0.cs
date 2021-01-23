		private Point _mdLocation;
		private void customButton1_MouseDown(object sender, MouseEventArgs e)
		{
			_mdLocation = e.Location;
		}
		private void customButton1_MouseMove(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				var x = this.Left + e.X - _mdLocation.X;
				var y = this.Top + e.Y - _mdLocation.Y;
				this.Location = new Point(x, y);
			}
		}
