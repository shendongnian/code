    public class SearchResultOffer : IEnumerable<SearchResultOffer1>
    {
        public SearchResultOffer1[] offers { get; set; }
        // Generic version for IEnumerable<T>
        public IEnumerator<SearchResultOffer1> GetEnumerator() 
        {
            return offers.GetEnumerator();
        }
        // Non generic version for IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
