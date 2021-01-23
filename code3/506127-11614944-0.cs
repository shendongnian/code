    public interface IHasRowKey
    {
       string RowKey {get;}
    }
    
    public class classname<T> where T : IHasRowKey
    {
       
    }
