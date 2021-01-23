    public sealed class MyActions <T> where T:new()
    { 
        public enum Methods { First, Second }  
        public virtual void Execute(T value, Methods methods = Methods.First)
        {
        }
    }
    //public class MiActionsSeconds<T> : MyActions <T>    where T:new()
    // {
    //     public override void Execute( T value, Methods methods = Methods.Second )
    //     {
    //         base.Execute( value, methods );
    //     }
    // }
    public class Foo<T>  where T:new()
    {
        public void Execute(MyActions<T> instance, MyActions<T>.Methods methods = Methods.First)
        {
            instance.Execute( default( T ) );
            instance.Execute( default( T ), MyActions<T>.Methods.Second );
        }
        public void Test()
        {
          //  Execute( new MiActionsSeconds<T>( ) );
        }
    }
