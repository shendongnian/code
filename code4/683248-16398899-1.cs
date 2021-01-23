    public interface IContext
    {
      IDbSet<Cat> Cats{get;set;}
    }
    public partial class MyEntities : DbContext , IContext
    {
        public IDbSet<Cat> Cats { get; set; }
    }
