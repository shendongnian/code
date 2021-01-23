    void Main()
    {
        IUnityContainer container = new UnityContainer();
        container.RegisterType<IAnimal, Dog>();
		
        // Exception thrown on this line
        var x = container.Resolve<IAnimal>();
    }
	
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
