    using System;
    using System.Net;
    using System.Net.Sockets;
    
    namespace CSharpSocket
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			string toSend = "Hello!";
    
    			IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse("192.168.0.6"), 4343);
    
    			Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    			clientSocket.Connect(serverAddress);
    
    			// Sending
    			int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
    			byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
    			byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
    			clientSocket.Send(toSendLenBytes);
    			clientSocket.Send(toSendBytes);
    
    			// Receiving
    			byte[] rcvLenBytes = new byte[4];
    			clientSocket.Receive(rcvLenBytes);
    			int rcvLen = System.BitConverter.ToInt32(rcvLenBytes, 0);
    			byte[] rcvBytes = new byte[rcvLen];
    			clientSocket.Receive(rcvBytes);
    			String rcv = System.Text.Encoding.ASCII.GetString(rcvBytes);
    
    			Console.WriteLine("Client received: " + rcv);
    
    			clientSocket.Close();
    		}
    	}
    }
