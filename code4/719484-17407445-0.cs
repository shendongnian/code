	public class RestaurantVM
	{
        public int Id { get; set; }
	    public string Name { get; set; }
	    public City City { get; set; }
	    public List<MealVM> Meals { get; set; }
	}
	public class MealVM
	{
	    public int Id { get; set; }
	    public string Name { get; set; }
	    public DateTime Date { get; set; }
	    public int Price { get; set; }
	    public int Number { get; set; }
	    public int Kind { get; set; }
	}
