    public class ObjectIdCollection : List<ObjectId>
    {
        public ObjectIdCollection() { }
        public ObjectId this[string classname]
        {
            get
            {
                foreach(ObjectId id in this) if(id.ClassName == classname) return id;
                return null;
            }
        }
    }
