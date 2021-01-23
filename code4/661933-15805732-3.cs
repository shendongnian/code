    class Program
    	{
    		static void Main(string[] args)
    		{
    			User u = new User { Name = "My", Surname = "Name" };
    			Mapper.CreateMap<User, UserModel>().ForMember(dest => dest.FullName, o => o.MapFrom(src => string.Format("{0} {1}", src.Name, src.Surname)));
    			
    			UserModel um = Mapper.Map<User, UserModel>(u);
    			Console.WriteLine(um.FullName);
    		}
    	}
    
    	public class User
    	{
    		public string Name { get; set; }
    		public string Surname { get; set; }
    	}
    
    	public class UserModel
    	{
    		public string Name { get; set; }
    		public string Surname { get; set; }
    		public string FullName { get; set; }
    	}
