	var result = cakes
		.SelectMany(c => c.Ingrediants.Select(i => new
			{
				c.CakeName,
				Ingredient = i
			}))
		.GroupBy(x => x.Ingredient)
		.Select(g => new
			{
				Ingredient = g.Key,
				Cakes = g.Select(x=>x.CakeName).ToArray()
			});
