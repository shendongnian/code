    void Main()
    {
    	List<Peoples> peopleList = new List<Peoples>(); 
    	peopleList.Add(new Peoples() { Name = "xxx", Age = 23 });
    	peopleList.Add(new Peoples() { Name = "yyy", Age = 25 });
    	var people =(from item in peopleList
    	select new XElement("people",
    									new XElement("name", item.Name),
    									new XElement("age", item.Age)
    								));
    	Console.WriteLine (people.First());
    	Console.WriteLine (people.Last());
    }
    
    class Peoples
    {
    	public string Name {get;set;}
    	public int Age {get;set;}
    }
