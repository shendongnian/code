    public class Server
    {
    	public Server()
    	{
    
    	}
    
    	public void Listen()
    	{
    		Task.Run(() =>
    		{
    			using (var context = new Context())
    			{
    				//Open a socket to reply
    				using (var socket = context.Socket(SocketType.REP))
    				{
    					socket.Bind("tcp://127.0.0.1:32500");
    					while (true)
    					{
    						//Again you could also receive binary data if you want
    						var request = socket.Recv(Encoding.UTF8);
    						var response = ReverseString(request);
    						socket.Send(response, Encoding.UTF8);
    					}
    				}
    			}
    		});
    	}
    
    	private string ReverseString(string request)
    	{
    		var chars = request.ToCharArray();
    		Array.Reverse(chars);
    		return new string(chars);
    	}
    }
