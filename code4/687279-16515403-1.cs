    public class A
    {
        public static void Clear()
        {
            //static member 
            RestMethods.ClearAllStaticMethods(typeof(A));
        }
        public void Clear()
        {
            //instance member
            RestMethods.ClearAllStaticMethods(GetType());
        }
    }
