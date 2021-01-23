        public IDictionary<int,string> Populatelist( )
        {
            var expectedResult =_repository.Populate(category => new {category.CategoryID, category.CategoryName}).ToList();
            return expectedResult.ToDictionary(c => c.CategoryID, c => c.CategoryName);
        }
