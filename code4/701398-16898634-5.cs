    public class RootViewModel :INotifyPropertyChanged
	{
		#region Implementation of INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged = delegate {};
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion
		private double _x;
		private double _y;
		public double X
		{
			get { return _x; }
			set
			{
				_x = value;
				OnPropertyChanged("X");
			}
		}
		public double Y
		{
			get { return _y; }
			set
			{
				_y = value;
				OnPropertyChanged("Y");
			}
		}
		public double XY
		{
			get { return _x * _y; }
		}
	}
