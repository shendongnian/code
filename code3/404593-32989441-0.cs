    public class ReturnMessage<T>
    {
	    //indicates success or failure of the function
	    public bool IsSuccess { get; set; }
	    //messages(if any)
	    public string Message { get; set; }
	    //data (if any)
	    public T Data { get; set; }
    }
