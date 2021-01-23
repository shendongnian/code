	private bool clicado = false;
	private Point lm = new Point();
	void PnMouseDown(object sender, MouseEventArgs e)
	{
		clicado = true;
		this.lm = MousePosition;
	}
	
	void PnMouseUp(object sender, MouseEventArgs e)
	{
		clicado = false;
	}
	
	void PnMouseMove(object sender, MouseEventArgs e)
	{
		if(clicado)
		{
			this.Left += (MousePosition.X - this.lm.X);
			this.Top += (MousePosition.Y - this.lm.Y);
			this.lm = MousePosition;
		}
	}
