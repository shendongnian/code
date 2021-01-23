    public class ContainerClass
    {
        ...
        [Editor(typeof(MyCollectionEditor), typeof(UITypeEditor))]
        public List<ContainerBase> Containers { get; set; }
        ...
    }
