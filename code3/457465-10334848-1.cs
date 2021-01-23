	void Main()
	{
		var m=new Monkey();
		m.RunMethod("A",1);
		m.RunMethod("A","frog");
	}
	
	class Monkey
	{
		public void A(int a)
		{
			Console.WriteLine("int A called");
		}
		public void A(string s)
		{
			Console.WriteLine("string A called");
		}
	}
	
