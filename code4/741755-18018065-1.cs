    public sealed class MyCollectionEditor : CollectionEditor // need a reference to System.Design.dll
    {
        public MyCollectionEditor(Type type)
            : base(type)
        {
        }
        protected override Type[] CreateNewItemTypes()
        {
            return new[] { typeof(ContainerBase), typeof(Bookbag), typeof(Bookcase) };
        }
    }
