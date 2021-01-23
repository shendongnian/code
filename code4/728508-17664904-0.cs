    public class GiveMeYourBuilder<P>
    {
       public P Me {get;set;}
       public T Pet<T>() : where T: new()
       { return new T();}
    }
    
    public static PetExtensions 
    {
        public GiveMeYourBuilder<P>(this P me)
        {
             return new GiveMeYourBuilder<P> { Me = me;}
        }
    }
