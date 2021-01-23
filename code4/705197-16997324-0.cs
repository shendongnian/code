		private string _property1;
		public string Property1
		{
				get{
					return _property1;
				}
				set
				{
					Property1 = value;
					OnPropertyChanged("Property1");
				}
		}
		
		private string _property2;
		public string Property2
		{
				get{
					return _property2;
				}
				set
				{
					if(value!=null)
					{
						Property2 = value;
					}else
					{
						Property2 = Property1;
					}					
					OnPropertyChanged("Property2");
				}
		}
		
	
	
