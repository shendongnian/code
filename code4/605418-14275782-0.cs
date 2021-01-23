    public class EntityHandler<T, V>
            where T : Entity<V>, new()
            where V : DataObject
        {
            private long myDataObjectID;
            private T myEntityObject;
            public delegate Entity<V> GetEntityObject(long oid);
    
            private GetEntityObject GetEntityObjectFunction;
    
            private Entity<V> HandledEntity
            {
                set
                {
                    if (myEntityObject == null)
                    {
                        myEntityObject = (T)value;
                    }
                }
                get { return myEntityObject; }
            }
    
            public EntityHandler(GetEntityObject extCntrGetBO, long oid)
            {
                myDataObjectID = oid;
                GetEntityObjectFunction = extCntrGetBO;
            }
    
            public T o
            {
                get
                {
                    if (myEntityObject == null)
                    {
                        myEntityObject = (T)GetEntityObjectFunction(myDataObjectID);
                    }
                    return myEntityObject;
                }
            }
    
            public long ID
            {
                get { return myDataObjectID; }
                set
                {
                    myDataObjectID = value;
                    myEntityObject = null;
                }
            }
        }
