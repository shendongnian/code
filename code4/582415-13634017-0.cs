    MouseButtonState _mouseButtonState;
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
	{
		_mouseButtonState = e.ButtonState;
	}
	private void Window_MouseMove(object sender, MouseEventArgs e)
	{
		if(_mouseButtonState == MouseButtonState.Pressed)
			DragMove();
	}
