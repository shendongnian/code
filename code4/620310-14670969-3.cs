    public interface IHTMLElementCollection : IEnumerable
    {
        ...
        [DispId(0)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object item(object name = Type.Missing, object index = Type.Missing);
        ...
    }
