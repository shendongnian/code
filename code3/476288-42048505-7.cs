    public class MyContext : DbContext
    {
        private readonly OrphansToHandle OrphansToHandle;
        public DbSet<ParentObject> ParentObject { get; set; }
        public MyContext()
        {
            OrphansToHandle = new OrphansToHandle();
            OrphansToHandle.Add<ChildObject, ParentObject>();
        }
        public override int SaveChanges()
        {
            HandleOrphans();
            return base.SaveChanges();
        }
        private void HandleOrphans()
        {
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;
            objectContext.DetectChanges();
            var deletedThings = objectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Deleted).ToList();
            foreach (var deletedThing in deletedThings)
            {
                if (deletedThing.IsRelationship)
                {
                    var entityToDelete = IdentifyEntityToDelete(objectContext, deletedThing);
                    if (entityToDelete != null)
                    {
                        objectContext.DeleteObject(entityToDelete);
                    }
                }
            }
        }
        private object IdentifyEntityToDelete(ObjectContext objectContext, ObjectStateEntry deletedThing)
        {
            // The order is not guaranteed, we have to find which one has to be deleted
            var entityKeyOne = objectContext.GetObjectByKey((EntityKey)deletedThing.OriginalValues[0]);
            var entityKeyTwo = objectContext.GetObjectByKey((EntityKey)deletedThing.OriginalValues[1]);
            foreach (var item in OrphansToHandle.List)
            {
                if (IsInstanceOf(entityKeyOne, item.ChildToDelete) && IsInstanceOf(entityKeyTwo, item.Parent))
                {
                    return entityKeyOne;
                }
                if (IsInstanceOf(entityKeyOne, item.Parent) && IsInstanceOf(entityKeyTwo, item.ChildToDelete))
                {
                    return entityKeyTwo;
                }
            }
            return null;
        }
        private bool IsInstanceOf(object obj, Type type)
        {
            // Sometimes it's a plain class, sometimes it's a DynamicProxy, we check for both.
            return
                type == obj.GetType() ||
                (
                    obj.GetType().Namespace == "System.Data.Entity.DynamicProxies" &&
                    type == obj.GetType().BaseType
                );
        }
    }
    public class OrphansToHandle
    {
        public IList<EntityPairDto> List { get; private set; }
        public OrphansToHandle()
        {
            List = new List<EntityPairDto>();
        }
        public void Add<TChildObjectToDelete, TParentObject>()
        {
            List.Add(new EntityPairDto() { ChildToDelete = typeof(TChildObjectToDelete), Parent = typeof(TParentObject) });
        }
    }
    public class EntityPairDto
    {
        public Type ChildToDelete { get; set; }
        public Type Parent { get; set; }
    }
