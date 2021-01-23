    public class EData<T> 
    {
        public static T All()
        { return (T) ..... }
    }
    public class EHouse : EData<EHouse> { }
