    public class ViewModel {
    	[Required]
    	public string UserName { get; set; }
    	
    	[Required, DataType(DataTypes.Password)]
    	public string Password { get; set; }
    }
