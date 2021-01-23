	public class CategoryMapViewModel
	{
		public HtmlString Map { get; private set; }
		private List<int?> TakenIds = new List<int?>();
		private List<PostCategoryModels> _categories;
		
		public CategoryMapViewModel(List<PostCategoryModels> categoriesModels)
		{	 
			_categories = categoriesModels ?? new List<PostCategoryModels>();
			string map = BuildCategoriesMap(_categories);
			this.Map = new HtmlString(map);
		}
		private string BuildCategoriesMap(List<PostCategoryModels> categories)
		{
			var map = "";
			if (categories.Count > 0)
			{
				map += "<ul>";
				foreach (PostCategoryModels cat in categories)
				{
					if ((!cat.CategoryId.HasValue) || (cat.CategoryId.HasValue && (!TakenIds.Contains(cat.CategoryId))))
					{
						map += "<li>" + cat.Name;
						List<PostCategoryModels> subCats = _categories.Where(c => c.IdPostCategoryParent == cat.CategoryId).ToList();
						map += BuildCategoriesMap(subCats);
						map += "</li>";
					}
					TakenIds.Add(cat.CategoryId);
				}
				map += "</ul>";
			}
			return map;
		}
	}
