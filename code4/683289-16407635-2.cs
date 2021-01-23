    public interface IResult {
    	string Status{get;set;}
    }
    
    [DataContract]
    public class ActivateUserResult : IResult {
    
    	[DataMember]
    	public string CryptedPassword { get; set; }
    
        [DataMember]
    	public string Status { get; set; }
    }
