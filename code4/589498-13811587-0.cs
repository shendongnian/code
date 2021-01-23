    abstract class A
    {
       // some protected variables...
    }
    abstract class A<T> : A
    {
        public void SharedMethodHappensAlways()
        {          
            List<A> src = new List<A>();
            var childResult = GetData<T>(src);            
        }    
        public T GetData<T>(List<A> src)
        {
            return src.OfType<T>().FirstOrDefault();
        }
    }    
    class B : A<B>
    {      
    }
    class C : A<C>
    {
    }
