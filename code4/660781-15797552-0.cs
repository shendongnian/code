    	public class ObservableLinkedList<T> : Collection<T>, INotifyPropertyChanged, INotifyCollectionChanged
	{
		public event NotifyCollectionChangedEventHandler CollectionChanged;
		public event PropertyChangedEventHandler PropertyChanged;
		private LinkedList<T> _list = new LinkedList<T>();
		public ObservableLinkedList()
		{
		}
		public void Clear()
		{
			_list.Clear();
		}
		public int Count()
		{
			return _list.Count();
		}
		public void Add(T artist)
		{
			_list.AddLast(artist);
		}
		public Model.Artist Find(string p)
		{
			return null;
		}
	}
