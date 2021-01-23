    public interface IRepository { ... }
    
    public class RealRepository : IRepository { ... }
    public class MockRepository : IRepository { ... }
    
    class MyController { public IRepository { get; set; }
