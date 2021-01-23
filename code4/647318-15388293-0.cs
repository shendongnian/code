    public class Generic
    {
    	protected Generic(string name, int age)
    	{
    		Name = name;
    		Age = age;
    	}
    
    	public string Name { get; private set; }
    	public int Age { get; private set; }
    }
    
    public class Human : Generic 
    {
    	public Human(string name, string surname, int age) : base(name, age)
    	{
    		Surname = surname;
    	}
    
    	public string Surname { get; private set; }
    }
    
    public class Pet : Generic
    {
    	public Pet(string name, int registrationCode, int age)
    		: base(name, age)
    	{
    		RegistrationCode = registrationCode;
    	}
    
    	public int RegistrationCode { get; private set; }
    }
    
    
    static void Main(string[] args)
    {
    	IEnumerable<Pet> pets = new List<Pet>();
    	IEnumerable<Human> palls = new List<Human>();
    
    	var resPets = SelectAgeGreaterThen10<Pet>(from p in pets where p.Name.StartsWith("A") select p);
    	var resHumans = SelectAgeGreaterThen10<Human>(from p in palls where p.Name.StartsWith("B") select p);
    
    }
    
    private static IEnumerable<T> SelectAgeGreaterThen10<T>(IEnumerable<Generic> source) where T : Generic
    {
    	return from s in source where s.Age > 10 select (T)s;
    }
