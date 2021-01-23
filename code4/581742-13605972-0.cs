	private class MyJsonClass
	{
		public string title { get; set; }
		public UserPrice user_price { get; set; }
		public int local_quantity { get; set; }
		...
	}
	
	private class UserPrice
	{
		public decimal inc_tax_value { get; set; }
		public decimal ex_tax_value { get; set; }
		...
	}
