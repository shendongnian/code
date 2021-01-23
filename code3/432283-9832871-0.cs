	public class ViewModel {
	
		[Required]
		public int SelectListValue { get; set; }
		public IDictionary<String,String> SelectListOptions { 
			get { 
				return new Dictionary<String, String>{
														{ "0", Resources.Option1},
														{ "1", Resources.Option2},
														{ "2", Resources.Option3}
													 }; 
			} 
		}
		
