    public class ArrayOrderBook : IEnumerable<PriceLevel>
    {
        private PriceLevel[] PriceLevels = new PriceLevel[500];
    
        public IEnumerator<PriceLevel> GetEnumerator()
        {
            return PriceLevels.AsEnumerable().GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return PriceLevels.GetEnumerator();
        }
    }
