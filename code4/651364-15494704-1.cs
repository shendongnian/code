    class MyObject<T> : IEquatable<MyObject<T>>
    { // no generic constraints
        private readonly string otherProp;
        private readonly T value;
        public MyObject(string otherProp, T value)
        {
            this.otherProp = otherProp;
            this.value = value;
        }
        public string OtherProp { get { return this.otherProp; } }
        public T Value { get { return this.value; } }
        // ...
        public bool Equals(MyObject<T> other)
        {
            if (other == null)
            {
                return false;
            }
         var cheker =   EqualityChekerCreator<T>.CreateEqualityChecker(other.Value);
         if (cheker != null)
             return cheker.CheckEquality(this.Value, other.value);
            return this.OtherProp.Equals(other.OtherProp) && this.Value.Equals(other.Value);
        }
    }
    public static class  EqualityChekerCreator<T>
    {
        private static IEqualityCheker<T> checker;
        
        public static IEqualityCheker<T>  CreateEqualityChecker(T type)
        {
            var currenttype = type as IEnumerable<T>;
            if(currenttype!=null)
                checker = new SequenceEqualityChecker<T>();
            return checker;
        }
    }
    public  interface  IEqualityCheker<in T>
    {
        bool CheckEquality(T t1, T t2);
    }
    public class SequenceEqualityChecker <T> : IEqualityCheker<T>
    {
        #region Implementation of IEqualityCheker<in T>
        public bool CheckEquality(T t1, T t2)
        {
            // implement method here;
        }
        #endregion
    }
