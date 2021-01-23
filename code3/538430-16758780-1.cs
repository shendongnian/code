        ....
        var trees = results
            .GroupBy(x => x.RootId)
            .Select(singleTreeEntities => GenerateSingleEntity(singleTreeEntities.Key, singleTreeEntities))
 
        return trees;
    }
    
    private Entity GenerateSingleEntity(long id, IEnumerable<Entities> treeEntities)
    {
        var currEntity = treeEntities.SingleOrDefault(x => x.Id == id);
 
        return new Entity
        {
            Id = id,
            SomeData = currEntity.SubEntity.SomeData,
            SomeOtherData = currEntity.SubEntity.SomeOtherData,
            ChildEntities =
                treeEntities
                    .Where(x => x.ParentId == id)
                    .Select(x => GenerateSingleEntity(x.Id, treeEntities)))
        };
    }
