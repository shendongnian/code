    public abstract class MyObject
    {
        public int ItemId { get; set; }
        public virtual string URL { get { return "#"; } }
    }
    public class MyObjectType3 : MyObject
    {
        public override string URL { get { return "/do/this/" + ItemId; } }
    }
    public class MyObjectType5 : MyObject
    {
        public override string URL { get { return "/do/that/" + ItemId; } }
    }
