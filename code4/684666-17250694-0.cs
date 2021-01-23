	public partial class MainWindow : Window, INotifyPropertyChanged, INotifyPropertyChanging
	{
		public class MyObj
		{
			public string Test1 { get; set; }
			public string Test2 { get; set; }
		}
		public MainWindow()
		{
			InitializeComponent();
			TestBinding = new ObservableCollection<MyObj>();
			for (int i = 0; i < 5; i++)
			{
				TestBinding.Add(new MyObj() { Test1 = "sdasads", Test2 = "sdsasa" });
			}
			DataContext = this;
		}
		#region TestBinding
		private ObservableCollection<MyObj> _testBinding;
		public ObservableCollection<MyObj> TestBinding
		{
			get
			{
				return _testBinding;
			}
			set
			{
				if (_testBinding != value)
				{
					NotifyPropertyChanging("TestBinding");
					_testBinding = value;
					NotifyPropertyChanged("TestBinding");
				}
			}
		}
		#endregion
		#region selectedItem
		private MyObj _selectedItem;
		public MyObj selectedItem
		{
			get
			{
				return _selectedItem;
			}
			set
			{
				if (_selectedItem != value)
				{
					NotifyPropertyChanging("selectedItem");
					_selectedItem = value;
					NotifyPropertyChanged("selectedItem");
				}
			}
		}
		#endregion
		#region INotifyPropertyChanged Members
		public event PropertyChangedEventHandler PropertyChanged;
		// Used to notify the page that a data context property changed
		protected void NotifyPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion
		#region INotifyPropertyChanging Members
		public event PropertyChangingEventHandler PropertyChanging;
		// Used to notify the data context that a data context property is about to change
		protected void NotifyPropertyChanging(string propertyName)
		{
			if (PropertyChanging != null)
			{
				PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
			}
		}
		#endregion
	}
