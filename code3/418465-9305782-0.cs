	private IEnumerable _ChartDataCollection;
	public IEnumerable ChartDataCollection
	{
		get
		{
			return _ChartDataCollection;
		}
		set
		{
			if (_ChartDataCollection != value)
			{
				_ChartDataCollection = value;
				NotifyPropertyChanged("ChartDataCollection");
			}
		}
	}
