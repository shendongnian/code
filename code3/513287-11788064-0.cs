    public class MockGolfEntities : DbContext, IContext
    {
        public MockGolfEntities() {}
    
        public IDbSet<Golfer> Golfers { get; set;}
    
    }
