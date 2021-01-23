    public class MainViewModel
    	{
    		private readonly Lazy<ObservableCollection<Person>> _people = new Lazy<ObservableCollection<Person>>(
    			() =>
    				{
    					return new ObservableCollection<Person>
    					       	{
    					       		new Person {Department = "Dept1", FirstName = "Person", LastName = "1"},
    					       		new Person {Department = "Dept2", FirstName = "Person", LastName = "2"},
    					       	};
    				});
    		public ObservableCollection<Person> People { get { return _people.Value; } }
    
    		public string Department
    		{
    			set
    			{
    				foreach (var p in People)
    					p.Department = value;
    			}
    		}
    	}
