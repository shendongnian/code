    public class EstimateDetailsModel : IEnumerable<string>
    {
        public string Dma { get; set; }
        public string Callsign { get; set; }
        public string Description { get; set; }
        public IEnumerator<string> GetEnumerator()
        {
            yield return Dma;
            yield return Callsign;
            yield return Description;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
