    public class MockSender: Sender
    {
        private WebRequest _response;
        public MockSender(WebRequest response)
        {
        _response=response;       //initialize data to be returned
        }
    	protected override WebRequest GetRequest(string URl)
    	{
    		//return your test;
    	}
    }
