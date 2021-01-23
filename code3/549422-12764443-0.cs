    List<MyEntity> results = new List<MyEntity>();
    foreach (item in setOfEntitiesToSearch) {
        results.AddRange(
            from myEntity in DataContext.MyEntityList           
            where myEntity.ForeignKeyOne == item.KeyOne && myEntity.ForeignKeyTwo == item.KeyTwo
            select myEntity).ToList()
        );
    }
    return results;
