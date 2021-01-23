    public class ReadOnlyBar
    {
    	public string name { get; private set; }
    	public double weight { get; private set; }
    	public int age { get; private set; }
    	
    	private readonly Friend[] _friendInstances;
    	
    	public IEnumerable<Friend> friendInstances
    	{
    		get
    		{
    			foreach(var friend in _friendInstances)
    				yield return friend;
    		}
    	}
    
    	public ReadOnlyBar(Bar bar)
    	{
    		this.name = bar.name;
    		this.weight = bar.weight;
    		this.age = bar.age;
    		this._friendInstances = bar.friendInstances.ToArray();
    	}
    }
