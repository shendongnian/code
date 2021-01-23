	Bitmap _completeFrame;
	protected override void OnPaint(PaintEventArgs pe)
	{
		DrawFrame(); // draws onto _completeFrame, calling new Bitmap() 
		             // when _completeFrame is null or its Size is wrong
		var g = pe.Graphics;
		g.DrawImage(_completeFrame, new Point());
	}
