	public bool HasBeenRead
	{
		get { return (bool)GetValue(HasBeenReadProperty); }
		set { SetValue(HasBeenReadProperty, value); OnHasBeenReadChanged(this, value); }
	}
	// Using a DependencyProperty as the backing store for HasBeenRead.  This enables animation, styling, binding, etc...
	public static readonly DependencyProperty HasBeenReadProperty =
		DependencyProperty.Register("HasBeenRead", typeof(bool), typeof(MyNewUserControl), new PropertyMetadata(false, OnHasBeenReadChanged));
