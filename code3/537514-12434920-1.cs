    public class PersistantTcpClient
    {
    TcpClient Client { get; set }
    public void Start()
	{
		try
		{
			 DoWork();
		}
		catch (SocketException)
		{
			while (true)
			{
				 try
				 {
					this.Client.Connect("host", port)
					
					// once it can connect, get back to work!
					DoWork();
				 }
				 catch (SocketException)
				 {
					// if it cannot connect, keep trying
				 }
			}
		}
	}
	
    }
