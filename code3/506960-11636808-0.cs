	public partial class App : Application, INotifyPropertyChanged
	{
		private bool _tooltipEnabled;
		public bool TooltipEnabled
		{
			get { return _tooltipEnabled; }
			set
			{
				if (_tooltipEnabled != value)
				{
					_tooltipEnabled = value;
					RaiseNotifyPropertyChanged("TooltipEnabled");
				}
			}
		}
		private void RaiseNotifyPropertyChanged(string property)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(property));
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
