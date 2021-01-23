		void AddCategory(List<Category> roots, Category categoryToAdd, string lineage)
		{
			List<Guid> categoryIdList = lineage.Split('/').Select(id => new Guid(id)).ToList();
			List<Category> currentNodes = roots;
			Category parentNode = null;
			foreach (Guid categoryId in categoryIdList)
			{
				parentNode = currentNodes.Where(category => category.CategoryId == categoryId).Single();
				currentNodes = parentNode.Children;
			}
			parentNode.Children.Add(categoryToAdd);
		}
