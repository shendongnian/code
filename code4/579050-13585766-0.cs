    public void UpdateEntities<TEntity>(ICollection<TEntity> pocoCollection, ICollection<TEntity> dbCollection)
            where TEntity : class, IEntity
        {
            // Archive deleted entities
            dbCollection.Where(x => x.ValidTo == null && !pocoCollection.Contains(x)).ToList().ForEach(x => x.ValidTo = DateTime.Now);
            // Add or update entities
            foreach (var entity in pocoCollection)
            {
                if (entity.Id == default(int))
                {
                    entity.ValidFrom = DateTime.Now;
                    dbCollection.Add(entity);
                }
                else
                {
                    var _entity = dbCollection.FirstOrDefault(x => x.Id == entity.Id);
                    context.Entry(_entity).CurrentValues.SetValues(entity);
                }
            }
        }
