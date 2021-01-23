    public class Interval
    {
       public long Start {get;set;}
       public long End{get;set;}
    
       public bool IsIn(Interval interval)
       {
          return Start >= interval.Start && End < interval.End;
       }
    
       public Interval Intersection(Interval interval)
       {
          if (interval == null)
            return false;
     
          if (IsIn(interval))
             return interval;
          if (interval.IsIn(this))
             return this;
          if ....
       }
    
       public Interval Union(Interval interval)
       {....}
    
       public bool IsIn(List<Interval> intervals)
       {
           return intrvals.Any(x=>IsIn(x));
       }
    
       public List<Interval> Intersect(List<Interval> intervals)
       {....}
       
       public List<Interval> Union(List<Interval> intervals)
       {....}
    }
