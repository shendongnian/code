    public class MainViewModel : ViewModelBase, IDataErrorInfo
    ...
    private ErrorCounter _errorCounter = new ErrorCounter();
    ...
	// Entry validation rules
    public string Error => string.Empty;
	public string this[string columnName]
	{
		get
		{
			switch (columnName)
			{
				case nameof(myProperty_1):
					if (string.IsNullOrWhiteSpace(myProperty_1))
						return _errorCounter.SetError(this, columnName, "Error 1");
					break;
				case nameof(myProperty_2):
					if (string.IsNullOrWhiteSpace(myProperty_2))
						return _errorCounter.SetError(this, columnName, "Error 2");
					break;
				default:
					break;
			}
			return _errorCounter.SetError(this, columnName, string.Empty);
		}
	}
