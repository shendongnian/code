    public abstract class BaseClass2<T>
    {
        public static Dictionary<Type, int> propertyStore = new Dictionary<Type, int>();
        public static int MyProperty
        {
            get
            {
                var t = typeof(T);
                return propertyStore[t];
            }
            set
            {
                var t = typeof(T);
                propertyStore[t] = value;
            }
        }
    }
    public class DerivedAlpha2 : BaseClass2<DerivedAlpha2>
    {
    }
    public class DerivedBeta2 : BaseClass2<DerivedBeta2>
    {
    }
            DerivedBeta2.MyProperty = 7;
            DerivedAlpha2.MyProperty = 8;
            // BaseClass2.MyProperty = 9;  // does not compile 
