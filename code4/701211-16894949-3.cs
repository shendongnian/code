    public ParentEntity Update(int id, string columnA, string columnB)
    {
        ParentEntity _entity = null;
        
        using (var context = new DBEntities())
        {
            bool isNew = false;
            
            _entity = context.ParentEntity
                .Include("ChildEntity")
                .SingleOrDefault(e => e.parent_id == id);
            ChildEntity entityChild = ParentEntity.ChildEntity.SingleOrDefault();
            
            if(entityChild == null)
            {
                entityChild = new ChildEntity();
                isNew = true;
            }
            
            entityChild.ColumnA = columnA;
            entityChild.ColumnB = columnB;
            
            if(isNew)
            {
                ParentEntity.ChildEntity.Add(entityChild);
            }
            
            context.SaveChanges();
        }
        
        return _entity;
    }
