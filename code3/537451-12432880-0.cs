    public class Util
    {
        public static T MyCustomWrapper<T>()
        {
            T customer = Axis.GetInstance<T>(); 
            return customer;
        }
    }
