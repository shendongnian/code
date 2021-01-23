    public class Singletone
    {
       public static readonly Singletone Instance = new Singletone();
    
       private Singletone() {}
       // other methods 
       public void DoTheJob(){}
    }
    
    // usage
    Singletone.Instance.DoTheJob();
