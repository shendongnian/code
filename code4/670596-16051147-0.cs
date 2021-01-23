    public class Farm<T> where T: Animal
    {
       public IList<T> Animals { get; set; }
       public Farm()
       {
          Animals = new List<T>();    
       }
    }
