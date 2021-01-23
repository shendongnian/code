	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }     
		public int CountryId { get; set; }
		
		[ForeignKey("CountryId")]
		public virtual Country Country { get; set; }
	}
	public class Country
	{
		public int Id { get; set; }
		public string CountryName { get; set; }
		public virtual ICollection<User> Users { get; set; }
	}
	User user = new User()
	{
		 Name = model.Name,
		 Surname = model.Surname,  
		 CountryId = 1;
	};
