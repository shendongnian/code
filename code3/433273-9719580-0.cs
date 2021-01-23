    public class ExtendedDataGridTextColumn : DataGridTextColumn
    {
	public ExtendedDataGridTextColumn() : base() { }
	public Visibility ColumnVisibility
	{
		get { return (Visibility)GetValue(ColumnVisibilityProperty); }
		set { SetValue(ColumnVisibilityProperty, value); }
	}
	public static readonly DependencyProperty ColumnVisibilityProperty =
		DependencyProperty.Register(
		"ColumnVisibility",
		typeof(Visibility),
		typeof(ExtendedDataGridTextColumn),
		new PropertyMetadata(ColumnVisibilityChanged));
	private static void ColumnVisibilityChanged(object sender, DependencyPropertyChangedEventArgs args)
	{
		ExtendedDataGridTextColumn column = sender as ExtendedDataGridTextColumn;
		if (args.NewValue != args.OldValue)
		{
			column.Visibility = (Visibility)args.NewValue;
		}
	}
    }
