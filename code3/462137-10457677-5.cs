    public sealed class MyActions <T> where T:new()
    { 
        public enum Methods { First, Second }  
        static Action<T>[] MethodsArray = { Method1, Method2 };
        public virtual void Execute(T value, Methods methods = Methods.First)
        {
            MethodsArray[(int) methods].Invoke(value);
        }
        private void Method1(T value) {}
        private void Method2(T value) {}
        
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
