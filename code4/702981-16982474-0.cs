    public partial class CachedMap : Map
    {
        public CachedMap() : base()
        {
            base.LoadingError += (s, e) =>
            {
                base.RootLayer.Children.RemoveAt(5);
            };
        }
    }
