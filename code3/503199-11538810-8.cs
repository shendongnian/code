    internal class MyCellViewModel : DependencyObject
    {
	private static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(MyCellViewModel));
	internal Brush Background
	{
		get { return (Brush)(GetValue(BackgroundProperty)); }
		set { SetValue(BackgroundProperty, value); }
	}
    }
