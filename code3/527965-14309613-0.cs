	// Constructor
	public MyClass()
	{
		{
			// _Window is private to this closure
			Window _Window;
			Show = () =>
			{
				if (_Window == null)
				{
					_Window = new Window();
					_Window.Closed += delegate { _Window = null; };
					_Window.Show();
				}
				_Window.BringIntoView();
			};
		}
	}
	// Replaces Show method
	private Action Show;
