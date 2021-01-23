	private bool _ThresholdLocked;
	public bool ThresholdLocked
	{
		get { return _ThresholdLocked; }
		set
		{
			if (value != _ThresholdLocked)
			{
				_ThresholdLocked= value;
				OnPropertyChanged("ThresholdLocked");
				OnPropertyChanged("Value"); //Value is also affected
			}
		}
	}
	private float _Value;
	public float Value
	{
		get
		{
			if (ThresholdLocked)
				return 2.0f;
			return _Value;
		}
		set
		{
			if (value != _Value)
			{
				_Value = value;
				OnPropertyChanged("Value");
			}
		}
	}
