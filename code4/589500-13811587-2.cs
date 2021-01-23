    abstract class A
    {
        // protected members
        public abstract A GetData(List<A> src);
    
        public void SharedMethodHappensAlways()
        {
            List<A> src = new List<A>();
            var childResult = GetData(src);
        }  
    }
    
    abstract class A<T> : A
        where T: A
    {
        public T GetData<T>(List<A> src)
        {
            return src.OfType<T>().FirstOrDefault();
        }
    
        public override A GetData(List<A> src)
        {
            return GetData<T>(src);
        }
    }    
    
    class B : A<B>
    {    
    }
    
    class C : A<C>
    {    
    }
