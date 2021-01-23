    class Program
	{
		static void Main(string[] args)
		{
			Collection<Complex> complex = new Collection<Complex>();
            //TODO: Populate the collection with data
			Complex first = complex.First;
			Complex another = complex.Items[2];
		}
	}
	public class Complex
	{
		// implementation
	}
	public class Collection<T> where T : class
	{
		public List<T> Items { get; set; }
		public T First
		{
			get
			{
				return (Items.Count > 0) ? Items[1] : null;
			}
			set
			{
				if(Items.Count > 0) 
					Items[1] = value;
			}
		}
	}
