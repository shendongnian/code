    void Main()
    {
    	var pDal = new PersonDAL { Age = 3 };
    	
    	var ageFunc = Person.AgeExpression.Compile();
        var age = ageFunc(pDal);
    	// age is 3
    }
    
    // Define other methods and classes here
    
    // A data object
    public class PersonDAL
    {
        public int Age { get; set; }
    }
    
    // A business object
    public class Person
    {
    	public Person(PersonDAL dal)
    	{
    		this.dal = dal;
    	}
    	
        private PersonDAL dal { get; set; }
    
        public static Expression<Func<PersonDAL, int>> AgeExpression
        {
            get
            {
                return (root) => (root.Age);
            }
        }
    }
