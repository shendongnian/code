	using System;
	using System.Net;
	using System.Net.NetworkInformation;
	
	static void Main()
	{
	
		IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
		TcpConnectionInformation[] tcpConnections = ipGlobalProperties.GetActiveTcpConnections();
		
		foreach (TcpConnectionInformation tcpConnection in tcpConnections)
		{
			Console.WriteLine("Local {0}:{1}\nRemote {2}:{3}\nState:{4}",
							tcpConnection.LocalEndPoint.Address,
							tcpConnection.LocalEndPoint.Port,
							tcpConnection.RemoteEndPoint.Address,
							tcpConnection.RemoteEndPoint.Port,
							tcpConnection.State);
		}
	}
