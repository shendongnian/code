        private My_ViewModel _viewModel
        {
            get { return this.DataContext as My_ViewModel; }
        }
		public LinearGradientBrush DynamicColor
		{
			get { return (string)GetValue(DynamicColorProperty); }
			set { SetValue(DynamicColorProperty, value); }
		}
		public static readonly DependencyProperty DynamicColorProperty =
			DependencyProperty.Register("DynamicColor", typeof(LinearGradientBrush), typeof(YourUserControl),
			new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnDynamicColorPropertyChanged)));
		private static void OnDynamicColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
            ((YourUserControl)d).OnTrackerInstanceChanged(e);
		}
		protected virtual void OnDynamicColorPropertyChanged(DependencyPropertyChangedEventArgs e)
		{
			this._viewModel.DynamicColor = e.NewValue;
		}
    public class My_ViewModel : INotifyPropertyChanged
    {
        public LinearGradientBrush DynamicColor
        {
            get { return dynamicColor; }
            set 
            { 
                if(dynamicColor != value)
                {
                    dynamicColor = value;
                    OnPropertyChanged("DynamicColor");
                }
            }
        }
        private LinearGradientBrush dynamicColor;
    }
