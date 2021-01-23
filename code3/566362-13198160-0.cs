    public interface IPet
	{
		
	}
	
	public interface IDog : IPet
	{
		void Bark();	
	}
	
	public class Dog : IDog
	{
		public void Bark()
		{
			Console.WriteLine("Wouff!");	
		}
	}
	
