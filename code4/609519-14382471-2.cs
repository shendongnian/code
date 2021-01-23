	abstract class Item
	{
		public string Name { get; private set; }
		public abstract IEnumerable<Item> Ingredients { get; }
		public abstract IEnumerable<Item> ParseRecipe();
	
		protected Item(string name)
		{
			Name = name;
		}
	
		public static Item GetItem(string _name)
		{
			return items.Find(match => match.Name == _name);
		}
	}
	
	class Atom : Item
	{
		public Atom(string name) : base(name) { }
	
		public override IEnumerable<Item> Ingredients { get { return null; } }
		public override IEnumerable<Item> ParseRecipe()
		{
			return new[] { this };
		}
	}
	
	class Recipe : Item
	{
		public Recipe(string name, params Item[] ingredients) : base(name)
		{
			_ingredients = ingredients;
		}
		public Recipe(string name, params string[] ingredients) : base(name)
		{
			_ingredients = ingredients.Select(x => Item.GetItem(x));
		}
		private IEnumerable<Item> _ingredients;
		public override IEnumerable<Item> Ingredients { get { return _ingredients;} }
		public override IEnumerable<Item> ParseRecipe()
		{
			Console.WriteLine("1 " + this.Name + " = " 
                                     + String.Join(" + ", this.Ingredients.Select(x => "1 " + x.Name)));
			var components = new List<Item>();
			foreach(var ing in Ingredients)
			{
				components.AddRange(ing.ParseRecipe());
			}
			return components;
		} 
	}
