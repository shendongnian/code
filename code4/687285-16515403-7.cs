    public class A
    {
        public static void Clear()
        {
            //static member 
            RestMethods.ClearAllStaticValues(typeof(A));
        }
        public void ClearInstance()
        {
            //instance member
            RestMethods.ClearAllStaticValues(GetType());
        }
    }
