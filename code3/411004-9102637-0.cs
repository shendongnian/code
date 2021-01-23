    public class DoWork
    {
        public void MethodWorkA(List<long> theList, bool both) 
        {
            if (both)
            {
                MethodWork1(1);
                MethodWork2(1);
            }
            else MethodWork1(1);
        }
    
        public void MethodWork1(int parameters) { }
    
        public void MethodWork2(int parameters) { }
    }
