	public class PersonsViewmodel
	{
		public string FirstName { get; set; }// from DB
		public string LastName { get; set; }// from DB
		public string FullName 
		{ 
			get 
			{ 
				return Regex.Replace(FirstName, "[^a-zA-Z0-9]+", "-", RegexOptions.Compiled); 
			}
		}
	}
