    public interface IDoSomething
    {
       string DoSomething();
    }
    
    public interface IFirst : IDoSomething {}
    
    public interface ISecond : IDoSomething {}
