    public IList<CategoryViewModel> GetCategoryAssignments(Manufacturer mfr)
            {
                var categories = new List<CategoryViewModel>();
                foreach (var category in GetCategories())
                {
                    categories.Add(new CategoryViewModel
                    {
                        ID = category.ID,
                        Name = category.Name,
                        Assigned = mfr.Categories.Select(c => c.ID).Contains(category.ID)
                    });
                }
                return categories;
            }
