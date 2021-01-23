    public interface ISortableBySimilarity{
        Double MinSimilarity {get;}
        Double MaxSimilarity {get;}
        Int32 ObjectId {get;}
    }
    
    public class PriorityQueue<TSortable> where TSortable : new, ISortableBySimilarity{
        // ...
    }
