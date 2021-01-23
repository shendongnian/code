    static void Main(string[] args)
    {
    
    	List<User> users = new List<User>();
    	users.Add(new User() { Name = "Larry", Age = 35 });
    	users.Add(new User() { Name = "Bob", Age = 25 });
    	users.Add(new User() { Name = "Brian", Age = 30 });
    
    	NameComparer sorter = new NameComparer();
    	IEnumerable<User> sortedUsers = sorter.Sort(users);
    
    	NameComparer35 sorter35 = new NameComparer35();
    	IEnumerable<User> sortedUsers35 = sorter35.Sort(users);
    }
    
    public abstract class MyComparer<T> : IComparer<T> where T: User
    {
    	public abstract int Compare(T x, T y);
    
    	public IEnumerable<T> Sort(IEnumerable<T> items)
    	{
    		items.ToList().Sort(this);
    		return items;
    	}
    }
    
    public abstract class MyComparer35<T> where T : User
    {
    	public abstract IEnumerable<T> Sort(IEnumerable<T> items);
    }
    
    public class NameComparer35 : MyComparer35<User>
    {
    	public override IEnumerable<User> Sort(IEnumerable<User> items)
    	{
    		return items.OrderBy(u => u.Name);
    	}
    }
    
    public class NameComparer : MyComparer<User>
    {
    	public override int Compare(User x, User y)
    	{
    		return x.Name.CompareTo(y.Name);
    	}
    }
    
    public class AgeComparer : MyComparer<User>
    {
    	public override int Compare(User x, User y)
    	{
    		return x.Age.CompareTo(y.Age);
    	}
    }
    
    public class User
    {
    	public string Name { get; set; }
    	public int Age { get; set; }
    
    	public override string ToString()
    	{
    		return string.Format("{0} {1}", Name, Age);
    	}
    }
