    public interface IHTMLElementCollection : IEnumerable
    {
        ...
        [DispId(0)]
        dynamic item(object name = Type.Missing, object index = Type.Missing);
        ...
    }
