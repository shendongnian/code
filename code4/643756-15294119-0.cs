    interface ICopyMaker
    {
        void CopyFrom(ICopyMaker source);
    }
    abstract class Clazz<T> : ICopyMaker
    {
       public abstract void CopyFrom(Clazz<T> source);
       void ICopyMaker.CopyFrom(ICopyMaker source)
       {
           var src = source as Clazz<T>;
           if (src == null) return; // know how to copy only from the instances of the same type
           CopyFrom(src);
       }
    }
    class MyClass : Clazz<MyClass>
    {
        private List<ICopyMaker> _list = new List<ICopyMaker>();
        public override void CopyFrom(Clazz<MyClass> c)
        {
        //implementation
        }
    }
