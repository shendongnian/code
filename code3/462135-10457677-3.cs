    public class MyActions <T> where T:new()
    { 
        public enum Methods { First, Second }  
        public virtual void Execute<T>(T value, Methods methods = Methods.First)
        {
        }
    }
    public class MiActionsSecondMethod<T> : MyActions <T>    where T:new()
    {
        public override void Execute<T>( T value, Methods methods = Methods.Second )
        {
            base.Execute<T>( value, methods );
        }
    }
    public class Foo<T>  where T:new()
    {
        public void Execute(MyActions<T> instance)
        {
            instance.Execute( default( T ) );
            instance.Execute( default( T ), MyActions<T>.Methods.First );
        }
        public void Test()
        {
            Execute( new MiActionsSecondMethod<T>( ) );
        }
    }
