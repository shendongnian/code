    	public double X
		{
			get
			{
				return x;
			}
			set
			{
				if (value != x)
				{
					x= value;
					OnPropertyChanged("X");
                    VisualObjectUpdateMethod();
				}
			}
		}
		private double x;
