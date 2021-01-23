    public class Claim
    {
    	public String Type { get; set; }
    	public String Value { get; set; }
    	public static implicit operator Role(Claim claim)
    	{
    		return (Role)Enum.Parse(typeof(Role), claim.Value);
    	}
    	public static implicit operator Claim(Role role)
    	{
    		return new Claim() { Type = "Role", Value = role.ToString() };
    	}
    }
