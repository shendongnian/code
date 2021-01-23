            this.pictureBox.MouseMove += new MouseEventHandler((a, e) =>
			{
				Point h = this.PointToClient(System.Windows.Forms.Cursor.Position);
				if (h.X < 20)
				{
					if (h.Y < 20)
					{
						pictureBox.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
					}
					else if (h.Y > this.Size.Height - 20)
					{
						pictureBox.Cursor = System.Windows.Forms.Cursors.SizeNESW;
					}
					else
					{
						pictureBox.Cursor = System.Windows.Forms.Cursors.SizeWE;
					}
				}
				else if (h.X > this.Size.Width - 20)
				{
					if (h.Y < 20)
					{
						pictureBox.Cursor = System.Windows.Forms.Cursors.SizeNESW;
					}
					else if (h.Y > this.Size.Height - 20)
					{
						pictureBox.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
					}
					else
					{
						pictureBox.Cursor = System.Windows.Forms.Cursors.SizeWE;
					}
				}
				else if (h.Y < 20)
				{
					pictureBox.Cursor = System.Windows.Forms.Cursors.SizeNS;
				}
				else if (h.Y > this.Size.Height - 20)
				{
					pictureBox.Cursor = System.Windows.Forms.Cursors.SizeNS;
				}
				else
				{
					pictureBox.Cursor = System.Windows.Forms.Cursors.Default;
				}
			});
