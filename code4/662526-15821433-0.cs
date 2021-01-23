            Type repoType = repository.Item1.GetType(); // RepositoryType
            var method = repoType.GetMethod("FindBy"); // Method
            var entityType = repository.Item2; // EntityType
            // Should work
            IQueryable recordsToExpire = method.Invoke(repository.Item1, new Func<BaseEntity, bool>((x) => x.IsActive));
