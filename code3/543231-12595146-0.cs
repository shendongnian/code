        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			base.OnMouseLeftButtonDown(e);
			CaptureMouse();
			//_last = e.GetPosition(canvas);
			_last = e.GetPosition(this);
			isDragged = true;
		}
		protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			base.OnMouseLeftButtonUp(e);
			ReleaseMouseCapture();
			isDragged = false;
		}
