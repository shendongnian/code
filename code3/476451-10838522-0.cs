    [Export(typeof(ILiveCollection))]
    public class FooLiveCollection : ILiveCollection
    {
        [ImportingConstructor]
        public FooLiveCollection(ILog logger, IDriverConfig config)
        {
           // ...
