    public class Base : IBase
    {
       public bool DoSomething(IDoSomethingVisitor visitor)
       {
          visitor.DoSomething(this);
       }
    }
    public class Advanced : IAdvanced
    {
       public bool DoSomething(IDoSomethingVisitor visitor)
       {
          visitor.DoSomething(this);
       }
    }
