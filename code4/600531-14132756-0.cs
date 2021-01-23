	    void RaisePropertyChanged(PropertyChangedEventArgs args)
		{
			var handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}
			
		public string Name
		{
			set
			{
				_name = value;
				RaisePropertyChanged("Name"); // Property name is specified as string
			}
		}
