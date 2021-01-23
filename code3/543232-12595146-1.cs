    protected override void OnMouseMove(MouseEventArgs e)
		{
			if (isDragged == false)
				return;
			base.OnMouseMove(e);
			if (e.LeftButton == MouseButtonState.Pressed && IsMouseCaptured)
		   {
				var pos = e.GetPosition(this);
				var matrix = mt.Matrix; // it's a struct
				matrix.Translate(pos.X - _last.X, pos.Y - _last.Y);
				mt.Matrix = matrix;
				_last = pos;
		   }
		   
		}
