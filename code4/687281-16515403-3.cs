    public class A
    {
        public static void Clear()
        {
            //static member 
            RestMethods.ClearAllStaticValues(typeof(A));
        }
        public void Clear()
        {
            //instance member
            RestMethods.ClearAllStaticValues(GetType());
        }
    }
