    public class GenClass<T>
    {
         private List<T> ItemsList {get;set;}
         public Predicate<T> SomeCondition {get;set;}
         public bool UsePredicate {get;set;}
    
         public List<T> Items
         {
             get { return UsePredicate 
                       ? ItemsList.Where(SomeCondition).ToList() 
                       : ItemsList; }
         }
    }
