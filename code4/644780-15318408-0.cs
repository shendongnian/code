    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    
    public class UDPListener
    {
    	public static int Main()
    	{
    		var done = false;
    		var listener = new UdpClient(31337);
    		var ipe = new IPEndPoint("255.255.255.255", 31337);
    		var data = String.Empty;
    
    		byte[] rec_array;
    		try
    		{
    			while (!done)
    			{
    				rec_array = listener.Receive(ref ipe);
    				Console.WriteLine("Received a broadcast from {0}", ipe.ToString() );
    				data = Encoding.ASCII.GetString(rec_array, 0, rec_array.Length);
    				Console.WriteLine("Received: {0}\r\rn", data);
    			}
    		}
    		catch (Exception e)
    		{
    			Console.WriteLine(e.ToString());
    		}
    		
    		listener.Close();
    		return 0;
    	}
    }
