            //Type repoType = repository.Item1.GetType(); // RepositoryType
            //var method = repoType.GetMethod("FindBy"); // Method
            var entityType = repository.Item2; // EntityType
            // Should work
            LambdaExpression compatibleIsActiveLambda = SomeClass.CreateIsActiveLambda(entityType);
            dynamic someDynamicResult = repository.Item1.FindBy (compatibleIsActiveLambda as dynamic);
            IQueryable whichAtRuntimeShouldActuallyBeAnIQueryable = someDynamicResult;
