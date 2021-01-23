    public partial class UserDto
    {
    	public UserDto(user User)
    	{
    		UserID = user.UserID;
    		Title = user.Title;
    		//... and so on
    	}
    	public int UserID { get; set; }
    	public string Title { get; set; }
    	public string Email { get; set; }
    	public int RoleID { get; set; }
    	
    	//exclude the Role navigation property from your DTO
    }
