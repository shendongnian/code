    public void AddOrUpdate(MyEntity entity) {
        var dbEntity = _context.MyEntities
          .Include(e => e.RelatedEntitis)
          .Where(e => e.ID == entity.ID)
          .SingleOrDefault();
        //replace entities with those taken from the context
        var relatedEntities = _context.RelatedEntities;
        var detachedEntities = entity.RelatedEntities;
        entity.RelatedEntities = new List<RelatedEntity>();
        foreach (var ent in detachedEntities)
        {
          entity.RelatedEntities.Add(relatedEntities .Where(e => e.ID == hop.ID).SingleOrDefault());
        }
        var newRelated = entity.RelatedEntitis.ToList<RelatedEntity>();
        var dbRelated = dbEntity.RelatedEntity.ToList<RelatedEntity>();
        _context.Entry(dbEntity).CurrentValues.SetValues(entity);
        _context.Entry(dbEntity.RelatedEntity).CurrentValues.SetValues(entity.RelatedEntitis);
        var comparer = new EqualityComparer();
        var addedRelated = newRelated.Except(dbRelated, comparer).ToList<RelatedEntity>();
        var deletedRelated = dbRelated.Except(newRelated, comparer).ToList<RelatedEntity>();
        addedRelated.ForEach(e => dbEntity.RelatedEntity.Add(e));
        deletedRelated.ForEach(e => dbEntity.RelatedEntity.Remove(e));
    }
