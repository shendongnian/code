    [ComVisible(true),
     Guid("4C1D2E51-018B-4A7C-8A07-618452573E42"),
     InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IExtension
    {
        [DispId(1)]
        int Foo(string s);
        ...
    }
