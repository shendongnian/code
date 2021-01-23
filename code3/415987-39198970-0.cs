    public class BaseClass
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }
    }
    public class DerivedClass : BaseClass
    {
        public override string Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = "test";
            }
        }
    }
