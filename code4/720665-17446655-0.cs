    mActionRepository.Setup(m => m.Retrieve(
        It.IsAny<Expression<Func<ContainerAction, bool>>>(), 
        It.IsAny<IEnumerable<string>>()))
        .Returns<Expression<Func<ContainerAction, bool>>, IEnumerable<string>>(
            (predicate, includes) => queryable.Where(predicate));
