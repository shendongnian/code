     List<Entity> pivotedEntities = new List<Entity>();
            int index = 0;
            foreach (Entity entity in results)
            {
                index = pivotedEntities.IndexOf(e => e.Id == entity.Id);
                if (index>-1)
                {
                    pivotedEntities[index].RelatedEntities.Add(entity.RelatedEntity);
                }
                else
                {
                    pivotedEntities.Add(new Entity());
                }
            }
    
            return pivotedEntities.AsQueryable();
