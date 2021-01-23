    public static class LongListSelectorExtension
    {
	public static readonly DependencyProperty CommandProperty =
		DependencyProperty.RegisterAttached("Command",
			typeof(ICommand), typeof(LongListSelectorExtension),
			new PropertyMetadata(null, OnCommandChanged));
	public static ICommand GetCommand(LongListSelector selector)
	{
		return (ICommand)selector.GetValue(CommandProperty);
	}
	public static void SetCommand(LongListSelector selector, ICommand value)
	{
		selector.SetValue(CommandProperty, value);
	}
	private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var selector = d as LongListSelector;
		if (selector == null)
		{
			throw new ArgumentException(
				"You must set the Command attached property on an element that derives from LongListSelector.");
		}
		var oldCommand = e.OldValue as ICommand;
		if (oldCommand != null)
		{
			selector.SelectionChanged -= OnSelectionChanged;
		}
		var newCommand = e.NewValue as ICommand;
		if (newCommand != null)
		{
			selector.SelectionChanged += OnSelectionChanged;
		}
	}
	private static void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		var selector = sender as LongListSelector;
		var command = GetCommand(selector);
		if (command != null && selector.SelectedItem != null)
		{
			command.Execute(selector.SelectedItem);
		}
		selector.SelectedItem = null;
	}
    }
