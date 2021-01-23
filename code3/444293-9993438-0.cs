	public static class Serializer
	{
		public static byte[] Serialize<T>(T Obj) where T : Data;
		public static T Deserialize<T>(byte[] Data) where T : Data, new()
		{
                     T res = new T();
                     res.Deserialize(Data);
                     return res;
		}
	}
	public interface Data
	{
		public byte[] Serialize<T>(T obj);
		public T Deserialize<T>(byte[] Data);
	}
	class Program
	{
		static void Main(string[] args)
		{
			Serializer.Deserialize<Dummy>(new byte[20]);
		}
	}
	class Dummy : Data
	{
	}
