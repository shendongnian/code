				var products = dbContext.Products.ToList(); // Gets As List
				foreach (var product in products)
				{
					// edit the value, EF manages what is changed
					product.someField = "some new value";
				}
				dbContext.SaveChanges(); // Saves All Changes
