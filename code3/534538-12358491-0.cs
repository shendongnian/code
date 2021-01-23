	void Main()
	{
		IUnityContainer container = new UnityContainer();
		container.RegisterType<IAnimal, Dog>();
		
		var x = container.Resolve<IAnimal>();
		
		x.Dump();
	}
	
	// Define other methods and classes here
	public interface IAnimal
	{
	}
	
	public class Dog : IAnimal
	{
		public Dog()
		{
			throw new Exception();
		}
	}
