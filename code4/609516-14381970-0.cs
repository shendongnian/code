	public static IEnumerable<IEnumerable<Item>> SearchRecipe(string _search)
	{
		List<Recipe> item_recipes = recipes.FindAll(match => match.Result.Name == Item.GetItem(_search).Name);
		var ingredients = new List<IEnumerable<Item>>();
	
		foreach (Recipe recp in item_recipes)
		{
	
			foreach (Item ingredient in recp.Ingredients)
			{
				if (recipes.FindAll(match2 => match2.Result.Name == ingredient.Name).Count != 0)
				{
					ingredients.Add(SearchRecipe(ingredient.Name).SelectMany(x => x));
				}
				else
				{
					ingredients.Add(new[] { ingredient });
				}
			}
			Console.WriteLine(recp.Result.Name + " = " + String.Join(" + ", ingredients.SelectMany(x => x.Select(y => y.Name))));
		}
		return ingredients;
	}
