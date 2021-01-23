    namespace Managed {
    public class MyNETImplementation: NativeInterface
    {
        override void NativeMethod()
        {
           DoTheStuff_UsingNativeCode(); // possibly, call the ConcreteMethod
        }
    }
    } // namespace Managed
