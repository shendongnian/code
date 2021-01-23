    public interface IChild
    {
    }
    
    public interface IParent
    {
        List<IChild> Children { get; set; }
    }
    
    public class ChildA : IChild
    {
    }
    public class ChildB : IChild
    {
    }
    public class ParentA : IParent
    {
    
        public List<IChild> Children
        {
            get;
            set;
        }
    }
    public class ParentB : IParent
    {
        public List<IChild> Children
        {
            get;
            set;
        }
    }
