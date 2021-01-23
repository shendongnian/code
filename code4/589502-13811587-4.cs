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
        public override A GetData(List<A> src)
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
