    public ParentEntity GetById(int id)
    {
        using (var context = new DBEntities())
        {
            bool isNew = false;
            
            ParentEntity _entity = context.ParentEntity
                .Include("ChildEntity")
                .SingleOrDefault(e => e.parent_id == id);
            ChildEntity entityChild = ParentEntity.ChildEntity.SingleOrDefault();
            
            if(entityChild == null)
            {
                entityChild = new ChildEntity();
                isNew = true;
            }
            
            entityChild.ColumnA= txtA.Text;
            entityChild.ColumnB= txtB.Text;
            
            if(isNew)
            {
                ParentEntity.ChildEntity.Add(entityChild);
            }
            
            context.SaveChanges();
        }
    }
