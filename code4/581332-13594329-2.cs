    public class ExposesReadOnly
	{
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
			InternalDict = new Dictionary<int, NotReadOnly>();
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
			ExposesReadOnly exposesReadOnly = new ExposesReadOnly();
			exposesReadOnly.AddSomeValue();
			Console.WriteLine(exposesReadOnly.PublicList[1].Name);
			Console.ReadLine();
			exposesReadOnly.PublicList[1].Name = "This is not possible!";
		}
	}
