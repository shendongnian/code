    [Guid("a5ee0756-0cbb-4cf1-9a9c-509407d5eed6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IGreet
    {
        [DispId(1)]
        string Hello(string name);
        [DispId(2)]
        Object onHello { get; set; }
    }
