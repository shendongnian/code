    public class MyClass
	{
		private object _mylock = new object();
		private ObservableCollection<string> _myCollection = new ObservableCollection<string>();
		
		public void DoEnumerate()
		{
			lock (_mylock)
			{
				foreach (var item in _myCollection)
				{
					// Do something
				}
			}
		}
		
		public void Modify()
		{
			lock (_mylock)
			{
				// Modify the collection here
			}
		}
	}
