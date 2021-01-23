    public class InCageAttribute : Attribute
    { }
    
    public abstract class Animal
    {}
    
    [InCage]
    public class Hippo : Animal
    {}
    
    public class Human : Animal
    {}
    
    public IEnumerable<Type> GetCageableAnimals()
    {
    	return	GetAssemblyTypes(assembly:typeof(Animal).Assembly)
    		.Where(type=>IsDerivedFrom(type, typeof(Animal)))
    		.Where(type=>MarkedByAttribute(type,typeof(InCageAttribute)));
    }
