	public class Item : INofifyPropertyChanged
	{
		private string author; 
		public string Author
		{
			get { return author; }
			set 
			{
				author = value;
				var copy = PropertyChanged; // avoid concurrent changes
				if (copy != null)
					copy(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		...
	}
