    public class Weight
    {
       public Weight(decimal miligrams) { InMiligrams= miligrams;}
       public decimal InMiligrams {get;private set;}
       public decimal InGrams { get { return InMiligrams*1000; }}
      
       /* other conversions as properties */
    }
