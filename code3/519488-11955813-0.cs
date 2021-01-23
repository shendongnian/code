    public interface IChild
    {
    }
    public interface IParent<TChild> where TChild : IChild
    {
        List<TChild> a { get; set; } 
    }
    public class ChildA : IChild {  }   
    
    public class ChildB : IChild {  }   
    public class ParentA : IParent<ChildA>
    {
        public List<ChildA> a { get; set; }
    }
    public class ParentB : IParent<ChildB>
    {
        public List<ChildB> a { get; set; }
    }
