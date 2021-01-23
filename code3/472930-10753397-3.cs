    public class Model
	{
		public ModelObject ModelObject { get; set; }
	}
	public class ModelObject
	{
		public decimal? VatRate { get; set; }
		public SelectList VatRatesList { get; set; }
	}
