    class Program
	{
		static void Main(string[] args)
		{
			var x = new MyKeyedCollection();
			x.Add(new MyType() { Key = 110L, Value = 0.1 });
			x.Add(new MyType() { Key = 122L, Value = 0.1 });
			x.Add(new MyType() { Key = 233L, Value = 0.1 });
			x.Add(new MyType() { Key = 344L, Value = 0.1 });
			foreach(int key in x.Keys())
			{	
				Console.WriteLine(x[key].Key);
			}
			Console.Read();
		}
	}
	public class MyType
	{
		public long Key;
		public double Value;
	}
	public class MyKeyedCollection : KeyedCollection<long, MyType>
	{
		protected override long GetKeyForItem(MyType item)
		{
			return item.Key;
		}
		public IEnumerable<long> Keys()
		{
			foreach (MyType item in this.Items)
			{
				yield return GetKeyForItem(item);
			}
		}
	}
