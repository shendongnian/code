    set
			{
				//if (IsEditable)
				{
					//IsEditable = false;
					if (_name == value)
					{
						RaisePropertyChanged("Name");
						return;
					}
					// Do some back end stuff
					if (back //end stuff //worked)
					{
					    var oldValue = _name;
					    _name = value;
					    RaisePropertyChanged("Name");
					}
				}
