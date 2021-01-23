            //Type repoType = repository.Item1.GetType(); // RepositoryType
            //var method = repoType.GetMethod("FindBy"); // Method
            var entityType = repository.Item2; // EntityType
            // Should work
            dynamic someDynamicResult = repository.Item1.FindBy ((Expression<Func<BaseEntity, bool>>)((x) => x.IsActive));
            IQueryable whichAtRuntimeShouldActuallyBeAnIQueryable = someDynamicResult;
