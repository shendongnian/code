    public interface IResult {
    	[DataMember]
    	string Status{get;set;}
    }
    
    [DataContract]
    public class ActivateUserResult : IResult {
    
    	[DataMember]
    	public string CryptedPassword { get; set; }
    
    
    	public string Status { get; set; }
    }
