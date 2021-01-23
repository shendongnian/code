        public void Handle(ParentChanged e)
        {
            var categoryGuid = e.CategoryId.Id;
            var category = _context.Categories
                .Include(cat => cat.ParentCategory)
                .First(cat => cat.Id == categoryGuid);
            if (null != e.OldParentCategoryId)
            {
                var oldParentCategoryGuid = e.OldParentCategoryId.Id;
                if (category.ParentCategory.Id == oldParentCategoryGuid)
                {
                    throw new Exception("Old Parent Category mismatch.");
                }
            }
            (_context as DbContext).Configuration.LazyLoadingEnabled = true;
            RemoveFromAncestors(category, category.ParentCategory);
            var newParentCategoryGuid = e.NewParentCategoryId.Id;
            var parentCategory = _context.Categories
                .First(cat => cat.Id == newParentCategoryGuid);
            category.ParentCategory = parentCategory;
            AddToAncestors(category, category.ParentCategory);
            _context.Commit();
        }
        private static void RemoveFromAncestors(Model.Category.Category mainCategory, Model.Category.Category ancestorCategory)
        {
            if (null == ancestorCategory)
            {
                return;
            }
            while (true)
            {
                var offspring = ancestorCategory.Offspring;
                offspring?.RemoveAll(node => node.OffspringId == mainCategory.Id);
                if (null != ancestorCategory.ParentCategory)
                {
                    ancestorCategory = ancestorCategory.ParentCategory;
                    continue;
                }
                break;
            }
        }
        private static void AddToAncestors(Model.Category.Category mainCategory, Model.Category.Category ancestorCategory)
        {
            while (true)
            {
                var offspring = ancestorCategory.Offspring ?? new List<CategoryNode>();
                if (null == ancestorCategory.Ancestors)
                {
                    ancestorCategory.Ancestors = new List<CategoryNode>();
                }
                offspring.Add(new CategoryNode()
                {
                    Ancestor = ancestorCategory,
                    Offspring = mainCategory,
                    Separation = mainCategory.Ancestors.Count
                });
                if (null != ancestorCategory.ParentCategory)
                {
                    ancestorCategory = ancestorCategory.ParentCategory;
                    continue;
                }
                break;
            }
        }
