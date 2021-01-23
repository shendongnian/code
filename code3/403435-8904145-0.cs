    public class EstimateDetailsModel : IEnumerable<KeyValuePair<string, string>>
	{
		public string Dma { get; set; }
		public string CallSign { get; set; }
		public string Description { get; set; }
		public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
		{
			yield return new KeyValuePair<string, string>("Dma", Dma);
			yield return new KeyValuePair<string, string>("CallSign", CallSign);
			yield return new KeyValuePair<string, string>("Description", Description);
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
