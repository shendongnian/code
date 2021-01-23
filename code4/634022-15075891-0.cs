    using System;
    using System.Net.Sockets;
    namespace Stream
    {
    	class Program
    	{
    		private static TcpClient client;
    		private static NetworkStream stream;
    
    		static void Main(string[] args)
    		{
    			var p = new Program();
    			p.Run();
    		}
    
    		void Run()
    		{
    			try
    			{
    				client = new TcpClient("127.0.0.1", 80);
    				stream = client.GetStream();
    				byte[] buffer = new byte[64];
    
    				stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), buffer);
    
    				client.Close();
    				Console.ReadKey();
    			}
    			catch (Exception)
    			{
    				//...
    			}
    		}
    
    		void OnRead(IAsyncResult result)
    		{
    			try
    			{
    				stream.EndRead(result);
    				byte[] buffer = result.AsyncState as byte[];
    
    				if (buffer != null)
    				{
    					//...
    				}
    
                    // continue to read the next 64 bytes
    				buffer = new byte[64];
    				stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), buffer);
    			}
    			catch (Exception)
    			{
    				// From here you can get exceptions thrown during the asynchronous read
    			}
    		}
    	}
    }
