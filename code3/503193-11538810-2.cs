    internal class MyCellViewModel : DependencyObject
    {
	private static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(MyCellViewModel));
	internal XwpfFont Font
	{
		get { return (XwpfFonBrusht)(GetValue(BackgroundProperty)); }
		set { SetValue(BackgroundProperty, value); }
	}
    }
