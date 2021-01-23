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
            AddToAncestors(category, category.ParentCategory, 1);
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
        private static int AddToAncestors(Model.Category.Category mainCategory,
            Model.Category.Category ancestorCategory, int deep)
        {
            var offspring = ancestorCategory.Offspring ?? new List<CategoryNode>();
            if (null == ancestorCategory.Ancestors)
            {
                ancestorCategory.Ancestors = new List<CategoryNode>();
            }
            var node = new CategoryNode()
            {
                Ancestor = ancestorCategory,
                Offspring = mainCategory
            };
            offspring.Add(node);
            if (null != ancestorCategory.ParentCategory)
            {
                deep = AddToAncestors(mainCategory, ancestorCategory.ParentCategory, deep + 1);
            }
            node.Separation = deep;
            return deep;
        }
