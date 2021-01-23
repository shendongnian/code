    public interface IVisitable
    {
        string Visit(DescriptionVisitor visitor);
    }
    public class ClazzA : IVisitable
    {
        public virtual string Visit(DescriptionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
    public class ClazzB : ClazzA
    {
        public override string Visit(DescriptionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
    
    public class DescriptionVisitor
    {
        public string Visit(ClazzA item) { return "Description A"; }
        public string Visit(ClazzB item) { return "Description B"; }
    }
