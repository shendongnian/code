    void Main()
    {
    	var o1 = new ReactivePerson();
    
    	foreach (var element in Functions.GetProperties<ReactivePerson>())
    	{
    		o1.ObservableForProperty(element).Subscribe(x=>string.Format("property: {0} is changing to {1}",  x.GetPropertyName(), x.Value).Dump()); // note that the Dump() method is for LinqPad (http://www.linqpad.net/). Use console.log or similar if needed.
    	}
    	
    	// Both properties registered
    	o1.FirstName = "Jenny";
    	o1.FirstName = "Peter";
    	o1.FirstName = "Dave";
    	o1.LastName = "Peterson";
    	o1.LastName = "Jones";
    	o1.LastName = "Smith";
    }
    
    public static class Functions{
    	public static IList<Expression<Func<T,object>>> GetProperties<T>()
    	{
    		var result = new List<Expression<Func<T,object>>>();
    		var properties = typeof(T).GetProperties().Where(pi => pi.GetCustomAttributes(typeof(DataMemberAttribute), false).Any());
    		foreach (var property in properties)
    		{
    			var p = Expression.Parameter(typeof(T), "p");
    			//var prop = Expression.Convert(Expression.Property(p, property), typeof(Object)); 
    			// Note I think that you should use the expression.convert line, which allows you to handle Int32s etc. However, I 'think' that there's a but in RxUI6 which is blocking it. https://github.com/reactiveui/ReactiveUI/issues/659
    			var prop = Expression.Property(p, property); // try this instead
    			var keySelector = Expression.Lambda<Func<T, object>>(prop, p);
    			result.Add(keySelector);
    		}
    		return result;
    	}
    }
    public class ReactivePerson : ReactiveObject
    {
    	
    		[IgnoreDataMember] 
    		string _firstName;
            [DataMember] 
    		public string FirstName{
                get { return _firstName; }
                set { this.RaiseAndSetIfChanged(ref _firstName, value); }
            }
    		
    		[IgnoreDataMember] 
    		string _lastName;
            [DataMember] 
    		public string LastName{
                get { return _lastName; }
                set { this.RaiseAndSetIfChanged(ref _lastName, value); }
            }
    
    // 		int not working, see comment in Functions.GetProperties.		
    //		[IgnoreDataMember] 
    //		int _age;
    //        [DataMember] 
    //		public int Age{
    //            get { return _age; }
    //            set { this.RaiseAndSetIfChanged(ref _age, value); }
    //        }
    }
