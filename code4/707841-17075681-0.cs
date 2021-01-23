		public Game()
		{
			this.Size = new Size(300, 300);
			Ball b = new Ball();
			this.Controls.Add(b);
			this.KeyDown += new KeyEventHandler(b.CD);
		}
