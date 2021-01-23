	[ContentProperty("CustomItems")]
	public class MyCustomStackPanel : StackPanel
	{
		public MyCustomStackPanel()
		{
			CustomItems = new ObservableCollection<MyUserControl>();
		}
		private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.NewItems != null)
			{
				foreach (object element in e.NewItems)
				{
					Children.Add((UIElement) element);
				}
			}
			if (e.OldItems != null)
			{
				foreach (object element in e.OldItems)
				{
					Children.Remove((UIElement)element);
				}
			}
		}
		private ObservableCollection<MyUserControl> _customItems;
		public ObservableCollection<MyUserControl> CustomItems
		{
			get { return _customItems; }
			set
			{
				if(_customItems == value)
					return;
				if (_customItems != null)
					_customItems.CollectionChanged -= OnCollectionChanged;
				_customItems = value;
				if (_customItems != null)
					_customItems.CollectionChanged += OnCollectionChanged;
			}
		}
	}
