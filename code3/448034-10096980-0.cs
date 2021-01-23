    void Main()
    {
    	var list = new List<Person>(){ new Person(){ Id = 1 }, new Vampire(){ Id = 2 } };
    	var infected    = list.Where (x => x is Vampire);
    	var notInfected = list.Except(infected);
    }
    
    public class Person
    {
    	public long Id { get; set; }
    	public string Name { get; set; }
    }
    
    public class Vampire : Person
    {
    }
