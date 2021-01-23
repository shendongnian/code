    public class ExposesReadOnly
	{
		//Note: Make sure that you use your IReadOnly interface here, and add NotReadOnly values later 
		private IDictionary<int, IReadOnly> InternalDict { get; set; }
		public IReadOnlyDictionary<int, IReadOnly> PublicList
		{
			get
			{
				IReadOnlyDictionary<int, IReadOnly> dictionary = new ReadOnlyDictionary<int, IReadOnly>(InternalDict);
				return dictionary;
			}
		}
		private class NotReadOnly : IReadOnly
		{
			public string Name { get; set; }
		}
		public void AddSomeValue()
		{
			//You can use the dictionary as you wish inside the class, and also add some values
			//Here you use your NotReadOnly Class
			InternalDict = new Dictionary<int, IReadOnly>();
			InternalDict.Add(1, new NotReadOnly() { Name = "SomeValue" });
		}
	}
	public interface IReadOnly
	{
		string Name { get; }
	}
	class Program
	{
		static void Main(string[] args)
		{
			//Here you create your dictionary and do some internal stuff (in this chase add some value from the inside)
			ExposesReadOnly dictionary = new ExposesReadOnly();
			dictionary.AddSomeValue();
			//You can read from the public list
            //This returns "SomeValue"
			Console.WriteLine(dictionary.PublicList[1].Name);
			Console.ReadLine();
			//You cannot change the list from the outside
			dictionary.PublicList[1].Name = "This is not possible!";
		}
	}
