    public class RatioBag : IList<RatioAssociation>
    {
        private readonly IList<RatioAssociation> _items = new List<RatioAssociation>();
    
        public void Order(Func<RatioAssociation, int> func) {
            var ordered = _items.OrderBy(func);
            _items.Clear();
            ((List<RatioAssociation>)_items).AddRange(ordered);
        }
    }
