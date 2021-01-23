    public class ParentObject
    {
        public int Id { get; set; }
        public virtual List<ChildObject> ChildObjects { get; set; }
    }
    public class ChildObject
    {
        public int Id { get; set; }
        public virtual ParentObject ParentObject { get; set; }
    }
