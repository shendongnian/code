    public interface ICageable
    { }
    
    public abstract class Animal
    {}
    
    public class Hippo : Animal, ICageable
    {}
    
    public class Human : Animal, ICageable
    {}
    
    public IEnumerable<Type> GetCageableAnimals()
    {
    	return	GetAssemblyTypes(assembly:typeof(Animal).Assembly)
    		.Where(type=>IsDerivedFrom(type, typeof(Animal)))
    		.Where(type=>ImplementsInterface(type,typeof(ICageable)));
    }
