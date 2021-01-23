	public class SomeModel : ICustomValidation {
		
		[Required]
		public Boolean NamePresent { get; set; }
		
		[Required]
		public String Name { get; set; }
		
		public void PerformValidation(ModelStateDictionary modelState) {
			if( !NamePresent ) dict.Remove("Name");
		}
	}
