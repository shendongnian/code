	public sealed partial class MainPage : Page, INotifyPropertyChanged {
		private ObservableCollection<string> recentPatients = new ObservableCollection<string>();
		private IList<string> emptyList = new string[] { "This list is empty" };
		public MainPage()	{
			this.InitializeComponent();
			this.DataContext = this;
			this.recentPatients.CollectionChanged += OnCollectionChanged;
		}
		public IList<string> RecentPatients	{
			get { return recentPatients.Any() ? recentPatients : emptyList; }
		}
		private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)		{
			if (this.recentPatients.Count <= 1)	{
				// It could be a change between empty to non-empty.
				this.OnPropertyChanged("RecentPatients");
			}
		}
		// implement the INotifyPropertyChanged pattern here.
