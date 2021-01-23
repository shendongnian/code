    public class User
    {
    	public int Id { get; set; }
    	public int Name { get; set; }
    	
    	public ICollection<Meal> Meals { get; set; }
    }
