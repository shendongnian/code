        public string Path
        {
            get
            {
                var pathStack = new Stack<Category>();
                var parentCategory = Parent;
                while (parentCategory != null)
                {
                    pathStack.Push(parentCategory);
                    parentCategory = parentCategory.ParentCategory ;
                }
                return String.Join("/", pathStack.Select(cat => cat.Name));
            }
        }
