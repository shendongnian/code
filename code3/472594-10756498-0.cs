        public class ZMarshal : System.Runtime.InteropServices.ICustomMarshaler
    {
        static ZMarshal static_instance;
        object oo;
        public IntPtr MarshalManagedToNative(object o)
        {
            if (!(o is CMA))
               throw new System.Runtime.InteropServices.MarshalDirectiveException("Blabala");
            oo = o;
