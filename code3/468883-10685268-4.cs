		private int _selectedIndex;
		public int SelectedIndex
		{
			get { return _selectedIndex; }
			set
			{
				Set(() => SelectedIndex, ref _selectedIndex, value);
				RaisePropertyChanged(()=>CanDoSomething);
			}
		}
		public bool CanDoSomething
		{
			get { return _selectedIndex >= 0; }
		}
