		private FPGAViewModel _yourSelectedItem;
		public FPGAViewModel YourSelectedItem
		{
			get { return _yourSelectedItem; }
			set { _yourSelectedItem = value;
			OnPropertyChanged("YourSelectedItem");}
		}
