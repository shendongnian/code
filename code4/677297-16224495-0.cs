    public void Main()
    {
    	var people = new List<Person>()
    	{
    		new Person(){Name = "Jpe", BirthDate =DateTime.Parse("March 18, 1980")},
    		new Person(){Name = "Bob", BirthDate =DateTime.Parse("July 22, 1989")},
    		new Person(){Name = "Sarah", BirthDate =DateTime.Parse("Nov 5, 1995")}
    	};
    	
    	var firstExpression = System.Linq.Dynamic.DynamicExpression.ParseLambda<Person, bool>("BirthDate = @0", DateTime.Parse("July 22, 1989"));
    	//var secondExpression = System.Linq.Dynamic.DynamicExpression.ParseLambda<Person, bool>("Name = @0", "Nick");
    	//var finalExpression = Expression.And(firstExpression, secondExpression);
    	people.AsQueryable().Where(firstExpression).FirstOrDefault().Dump();
    }
    
    public class Person
    {
    	public string Name{get;set;}
    	public DateTime BirthDate {get;set;}
    }
