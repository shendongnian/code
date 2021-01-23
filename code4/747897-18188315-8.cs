    public void UpdateCategories(string[] selectedCategories, ManufacturerViewModel form)
            {
                if (selectedCategories == null)
                    selectedCategories = new string[] { };
                var selectedIds = selectedCategories.Select(c => int.Parse(c)).ToList();
                var assignedIds = form.Manufacturer.Categories.Select(c => c.ID).ToList();
                foreach (var category in GetCategories())
                {
                    if (selectedIds.Contains(category.ID))
                    {
                        if (!assignedIds.Contains(category.ID))
                            form.Manufacturer.Categories.Add(category);
                    }
                    else
                    {
                        if (assignedIds.Contains(category.ID))
                            form.Manufacturer.Categories.Remove(category);
                    }
                }
            }
