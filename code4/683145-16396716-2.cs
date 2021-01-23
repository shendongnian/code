    void Main()
    {
    	SomeMethod(new PersonCollection{{1, 2}, {3, 4}, {5, 6}});
    }
    void SomeMethod(PersonCollection pc)
    {
    }
    //...
    class Person
    {
    	public Person(int a, int b)
    	{
    	}
    }
    class PersonCollection:IEnumerable
    {
    	IList<Person> personList = new List<Person>();
    	public void Add(int a, int b)
    	{
    		personList.Add(new Person(a,b));
    	}
    	
    	public IEnumerator GetEnumerator()
    	{
    		return personList.GetEnumerator();
    	}
    }
