    public class ParentObject
    {
        public int Id { get; set; }
        public virtual ICollection<ChildObject> ChildObjects { get; set; }
        public ParentObject()
        {
            ChildObjects = new List<ChildObject>();
        }
    }
    public class ChildObject
    {
        public int Id { get; set; }
    }
