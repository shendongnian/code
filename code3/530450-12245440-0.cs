	public interface IMyItem<T> where T : class, IMyItem<T>
	{
		MyObservableCollection<T> Owner { get; set; }
	}
	public class MyItem : IMyItem<MyItem>
	{
		public MyObservableCollection<MyItem> Owner { get; set; }
	}
	public class MyObservableCollection<T> : ObservableCollection<T> where T : class, IMyItem<T>
	{
		protected override void InsertItem ( int index, T item )
		{
			base.InsertItem ( index, item );
			item.Owner = this;
		}
	}
