    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Net.Sockets;
    using System.Threading;
    using System.Net;
    using System.IO;
    using System.Reflection;
    
    namespace ServerThread
    {
    	public partial class ServerThread : Form
    	{
    		private TcpListener tcpListener;
    		private Thread listenThread;
    
    		public ServerThread()
    		{
    			InitializeComponent();
    
    			// Port number
    			int portNumber = 5656;
    			port.Text = portNumber.ToString();
    
    			// Create a TcpListener to cover all existent IP addresses with that port
    			this.tcpListener = new TcpListener(IPAddress.Any, portNumber);
    			// Create a Thread to listen to clients
    			this.listenThread = new Thread(new ThreadStart(ListenForClients));
    			this.listenThread.Start();
    
    		}
    
    		private void ListenForClients()
    		{
    			this.tcpListener.Start();
    
    			while (true)
    			{
    				// Blocks until a client has conected to the server
    				TcpClient client = this.tcpListener.AcceptTcpClient();
    
    				// Create a Thread to handle the conected client communication
    				Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
    				clientThread.Start(client);
    			}
    		}
    
    		private void HandleClientComm(object client)
    		{
    			// Receive data
    			TcpClient tcpClient = (TcpClient)client;
    			NetworkStream clientStream = tcpClient.GetStream();
    
    			while (true)
    			{
    				try
    				{
    					// Sending data
    					string filePath = "send/mysong.mp3"; // Your File Path;
    					byte[] fileData = File.ReadAllBytes(filePath); // The size of your file
    					byte[] fileSize = BitConverter.GetBytes(fileData.Length); // The size of yout file converted to a 4 byte array
    					byte[] clientData = new byte[fileSize.Length + fileData.Length]; // The total byte size of the data to be sent
    
    					fileSize.CopyTo(clientData, 0); // Copy to the file size byte array to the sending array (clientData) beginning the in the 0 index
    					fileData.CopyTo(clientData, 4); // Copy to the file data byte array to the sending array (clientData) beginning the in the 4 index
    
    					// Send the data to the client
    					clientStream.Write(clientData, 0, clientData.Length);
    					clientStream.Flush();
    
    
    					// Debug for the ListBox
    					if (statusList.InvokeRequired)
    					{
    						statusList.Invoke(new MethodInvoker(delegate {
    							statusList.Items.Add("Client IP: " + tcpClient.Client.RemoteEndPoint.ToString());
    							statusList.Items.Add("Client Data size: " + clientData.Length);
    						}));
    					}
    					
    				}
    				catch
    				{
    					// 
    					break;
    				}
    
    				if (statusList.InvokeRequired)
    				{
    					statusList.Invoke(new MethodInvoker(delegate
    					{
    						statusList.Items.Add("File successefully sent!");
    					}));
    				}
    
    				// Close the client
    				tcpClient.Close();
    			}
    
    		}
    	}
    }
