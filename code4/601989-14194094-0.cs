	public class Vendor
	{
		public string VendorName { get; set; }
		public IEnumerable<VendorInfo> VendorData { get; set; }
	}
	
	public class VendorInfo
	{
		public decimal Amount { get; set; }
		public decimal Tax { get; set; }
	}
	public class MyViewModel
	{
		public IEnumerable<Vendor> Vendors { get; set; }
	}
