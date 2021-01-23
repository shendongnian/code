		private int _selectedIndex;
		public int SelectedIndex
		{
			get { return _selectedIndex; }
			set
			{
				Set(() => SelectedIndex, ref _selectedIndex, value);
				RaisePropertyChanged(()=>CanDelete);
			}
		}
		public bool CanDelete
		{
			get { return _selectedIndex >= 0; }
		}
