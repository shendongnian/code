    class ChildObject
    {
        public int Attribute { get; set; }
    }
    class ParentObject
    {
        public IEnumerable<ChildObject> ChildobjectList { get; set; }
    }
