    abstract class A
    {
        // protected members...
        protected abstract A InternalGetData(List<A> src);
    
        public void SharedMethodHappensAlways()
        {
            List<A> src = new List<A>();
            var childResult = InternalGetData(src);
        }  
    }
    
    abstract class A<T> : A
        where T: A
    {   
        public T GetData(List<A> src)
        {
            return src.OfType<T>().FirstOrDefault();
        }
        protected override A InternalGetData(List<A> src)
        {
            return GetData(src);
        }
    }    
    
    class B : A<B>
    {    
    }
    
    class C : A<C>
    {    
    }
