	void Main()
	{
		var bc = new BadConstructor(1,2,3);
	}
	
	public class BadConstructor
	{
		public BadConstructor(int x, params int[] y) {  
			Console.Write("It's mee!");
		}
		public BadConstructor(params int[] y) {  
			Console.Write("No, it's not, its you!");
		}
	}
