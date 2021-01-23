    public class Request {
    	public Request(){
    		this.RequestDetail = new RequestDetail();
    	}
        public RequestDetail RequestDetail { get; set; }
    }
    public class RequestDetail{
        public string ObjectId { get; set; }
    }
