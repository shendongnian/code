	public class Drink : IEntity
	{
		public Drink()
		{
			Ingridients = new List<Ingredient>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Ingredient> Ingridients { get; set; }
		public string Approach { get; set; }
	}
	public class Ingredient : IEntity
	{
		public Ingredient()
		{
			Drinks = new List<Drink>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Drink> Drinks { get; set; }
	}
