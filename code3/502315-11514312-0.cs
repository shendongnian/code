	public class MyViewModel: INotifyPropertyChanged
	{
		public ObservableCollection<string> StationNames
		{
			get;
			private set;
		}
		public Something()
		{
			StationNames = new ObservableCollection<string>( new [] {_floorUnits.Unit.Select(f=>f.Name)});
			StationNames.Insert(0, "All");
		}
		private string _selectedStationName = null;
		public string SelectedStationName
		{
			get
			{
				return _selectedStationName;
			}
			set
			{
				_selectedStationName = value;
				FirePropertyChanged("SelectedStationName");
			}
		}
		private void FirePropertyChanged(string propertyName)
		{
			if ( PropertyChanged != null )
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
    }
