    public class Client
    {
    	public Client()
    	{
    
    	}
    
    	public string ReverseString(string message)
    	{
    		using (var context = new Context())
    		{
    			//Open a socket to request data
    			using (var socket = context.Socket(SocketType.REQ))
    			{
    				socket.Connect("tcp://127.0.0.1:32500");
    
    				//Send a string, you can send a byte[] as well, for example protobuf encoded data
    				socket.Send(message, Encoding.UTF8);
    				
    				//Get the response from the server
    				return socket.Recv(Encoding.UTF8);
    			}
    		}
    	}
    }
