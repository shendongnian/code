		public class MyViewModel : DependencyObject
		{
			//MyList Observable Collection
			private ObservableCollection<MyItemClass> _myList = new ObservableCollection<MyItemClass>();
			public ObservableCollection<MyItemClass> MyList { get { return _myList; } }
		}
