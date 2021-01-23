    public interface I {}
    public class D {} // Note that D does not even implement I!
    public class E
    {
        public static M<T>(T t)
        {
            D d1 = (D)t; // Illegal
            D d2 = (D)(object)t; // Legal
            D d3 = (D)(I)t; // Legal
        }    
    }
