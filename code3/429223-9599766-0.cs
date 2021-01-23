    public interface IMyProcessor { void Process(); }
    
    [Export(typeof(IMyProcessor)]
    public class FirstProc : IMyProcessor { ... }
    
    [Export(typeof(IMyProcessor)]
    public class SecondProc : IMyProcessor { ... }
    
    [Export]
    public class MyTest()
    {
       [ImportMany]
       public IMyProcessor[] MyProcessors { get; set; }
    }
      
