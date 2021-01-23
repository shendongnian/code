    public interface InnerDataContext
    {
       public CaveSystem System{get;}
    }
    public class DataContext
    {
       private InnerDataContext dc;
      
       public CaveSystem
       { get{ return dc.System; }}
    }
