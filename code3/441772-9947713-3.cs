    public class SomeClass : INotifyPropertyChanged
	{
		private string _name;
		private bool _isEditable;
		private DelegateCommand _editItemCmd;
		public SomeClass(string name) { _name = name;}
		
		public DelegateCommand EditItemCommand
		{
			get
			{
				return _editItemCmd ?? (_editItemCmd = new DelegateCommand(() => { IsEditable = true; }));
			}
		}
		public string Name
		{
			get { return _name; }
			set
			{
				if (_name == value)
					return;
				_name = value;
				RaisePropertyChanged("Name");
			}
		}
		
		public bool IsEditable
		{
			get { return _isEditable; }
			set
			{
				if(_isEditable == value)
					return;
				_isEditable = value;
				RaisePropertyChanged("IsEditable");
			}
		}
		private void RaisePropertyChanged(string propertyName)
		{
			if(PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
