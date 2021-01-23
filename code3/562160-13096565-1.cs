    public class ClazzA
    {
       public virtual string Accept(ClassVisitor visitor)
       {
          return visitor.Visit(this);
       }
    }
    
    public class ClazzB : ClazzA
    {
       public override string Accept(ClassVisitor visitor)
       {
          return visitor.Visit(this);
       }
    }
    
    public abstract class ClassVisitor
    {
      public abstract string Visit(ClazzA a);
      public abstract string Visit(ClazzB b);
    }
    
    public class GetDescriptionVisitor : ClassVisitor
    {
        public override string Visit(ClazzA a)
        {
           return "A";
        }
    
        public override string Visit(ClazzB b)
        {
           return "B";
        }
    }
    
