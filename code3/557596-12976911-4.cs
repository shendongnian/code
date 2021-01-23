    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("22341123-9264-12AB-C1A4-B4F112014C31")]
    public interface IComExposed
    {        
        void setDoubleArray(ref double[] myArray);
        //(...)
    }
