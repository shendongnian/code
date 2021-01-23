    public enum EntityType { Child1, Child2 };
    abstract class ParentObject
    {
        public EntityType et { get; set; }
    }
    class ChildClass : ParentObject
    {
        public int ChildClassProp { get; set; }
        public ChildClass()
        {
            this.et = EntityType.Child1;
        }
    }
    class ChildClass2 : ParentObject
    {
        public int ChildClass2Prop { get; set; }
        public ChildClass2()
        {
            this.et = EntityType.Child2;
        }
    }
