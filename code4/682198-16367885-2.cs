    static class ClaimExtensions
    {
    	public static Role ToRole(this Claim claim)
    	{
    		return (Role)Enum.Parse(typeof(Role), claim.Value);
    	}
    	public static Claim ToClaim(this Role role)
    	{
    		return new Claim() { Type = "Role", Value = role.ToString() };
    	}
    }
