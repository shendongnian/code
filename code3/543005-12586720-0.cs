     [ServiceContract(Name = "YourContract", Namespace = "http://....")]
     public interface YourServiceContract, 
      {
	    [OperationContract]
	    object GetObject(object searchCriteria);
       }
    public class YourClient : ClientBase<YourServiceContract>, YourServiceContract
    {
	    public YourClient (){ }
	    public YourClient (string endpointConfigurationName)
		: base(endpointConfigurationName){ }
	    public object GetObject(object searchCriteria)
	    {
		return base.Channel.GetObject(searchCriteria);
	    }
    }
