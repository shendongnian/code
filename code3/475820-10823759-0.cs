    static void Caller<T>(T val, Bla<T> cls)
	{
		Console.WriteLine(cls.Gar(val));
	}
	
    public class Bla <T>
	{
		public int Gar(T val)
		{
			return 1;
		}
		
		public int Gar(string val)
		{
			return 0;
		}
	}
