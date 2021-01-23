	public class ExtendedObservableCollection<T>: ObservableCollection<T>
	{
		public ExtendedObservableCollection()
		{
		}
		public ExtendedObservableCollection(IEnumerable<T> items)
			: base(items)
		{
		}
		public void Execute(Action<IList<T>> itemsAction)
		{
			itemsAction(Items);
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}
	}
