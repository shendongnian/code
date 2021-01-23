    public class StateTypeCustomMarshaller : ICustomMarshaler
    {
        public static ICustomMarshaler GetInstance(string s)
        {
            return new StateTypeCustomMarshaller();
        }
        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            return new state_type(pNativeData, false);
        }
        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            throw new NotImplementedException();
        }
        public void CleanUpNativeData(IntPtr pNativeData)
        {
            throw new NotImplementedException();
        }
        public void CleanUpManagedData(object ManagedObj)
        {
        }
        public int GetNativeDataSize()
        {
            throw new NotImplementedException();
        }
    }
   
    public delegate void ObserverDelegate(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StateTypeCustomMarshaller))]state_type state,
            double d);
