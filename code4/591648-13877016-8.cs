    // Of course you still want to use the non-generic class Base
    abstract class Base {
        public abstract int[] someArray { get; }
    }
    
    abstract class Base<T> : Base where T: Base<T> {
         // Will be created once for every T, i.e. every derived class.
         private static int[] _someArray;
         
         public override int[] someArray {
            get { return _someArray ?? (_someArray = CreateArray()); }
         }
         
         protected abstract int[] CreateArray();
    }
    
    sealed class Derived : Base<Derived> {
         protected sealed override int[] CreateArray() { 
             return new int[] { 1,2,3,4 };
         }
    }
    
    sealed class DerivedB : Base<DerivedB> {
        protected sealed override int[] CreateArray() {
            return new int[] { 2,3,4,5 };
        }
    }
