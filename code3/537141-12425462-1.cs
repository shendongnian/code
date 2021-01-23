    public class ChangeCollectionAdapter<T> : IChangeCollection<T>
    {
		private readonly ChangeCollection _changeCollection;
		
		public ChangeCollectionAdapter(ChangeCollection changeCollection)
		{
		    _changeCollection = changeCollection;
		}
		
		public bool MoreChangesAvailable 
		{ 
			get { return _changeCollection.MoreChangesAvailable; }
		}
		
		//other members
    }
