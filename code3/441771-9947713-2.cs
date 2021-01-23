    public class ViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<SomeClass> _items;
		private SomeClass _selectedItem;
		public ViewModel()
		{
			SelectedItem = Items.First(); 
		}
		public ObservableCollection<SomeClass> Items
		{
			get
			{
				if (_items == null)
				{
					_items = new ObservableCollection<SomeClass>();
					for (int i = 0; i < 10; i++) _items.Add(new SomeClass(string.Format("name {0}", i)));
				}
				return _items;
			}
		}
		public SomeClass SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				if (_selectedItem == value)
					return;
				_selectedItem = value;
				foreach (var item in Items) item.IsEditable = false;
				RaisePropertyChanged("SelectedItem");
			}
		}
		private void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
