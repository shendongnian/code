    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net.Sockets;
    using System.Net;
    using System.Threading;
    
    //Author : Kanishka 
    namespace ServerSocketApp
    {
    class Server
    {
     private TcpListener tcpListn = null;
     private Thread listenThread = null;
     private bool isServerListening = false;
    
     public Server()
     {
      tcpListn = new TcpListener(IPAddress.Any,8090);
      listenThread = new Thread(new ThreadStart(listeningToclients));
      this.isServerListening = true;
      listenThread.Start();
     }
    
     //listener
     private void listeningToclients()
     {
      tcpListn.Start();
      Console.WriteLine("Server started!");
      Console.WriteLine("Waiting for clients...");
      while (this.isServerListening)
      {
       TcpClient tcpClient = tcpListn.AcceptTcpClient();
       Thread clientThread = new Thread(new ParameterizedThreadStart(handleClient));
       clientThread.Start(tcpClient);
      }
    
     }
    
     //client handler
     private void handleClient(object clientObj)
     {
      TcpClient client = (TcpClient)clientObj;
      Console.WriteLine("Client connected!");
    
      NetworkStream stream = client.GetStream();
      ASCIIEncoding asciiEnco = new ASCIIEncoding();
    
      //read data from client
      byte[] byteBuffIn = new byte[client.ReceiveBufferSize];
      int length = stream.Read(byteBuffIn, 0, client.ReceiveBufferSize);
      StringBuilder clientMessage = new StringBuilder("");
      clientMessage.Append(asciiEnco.GetString(byteBuffIn));
    
      //write data to client
      //byte[] byteBuffOut = asciiEnco.GetBytes("Hello client! \n"+"You said : " + clientMessage.ToString() +"\n Your ID  : " + new Random().Next());
      //stream.Write(byteBuffOut, 0, byteBuffOut.Length);
      //writing data to the client is not required in this case
    
      stream.Flush();
      stream.Close();
      client.Close(); //close the client
     }
    
     public void stopServer()
     {
      this.isServerListening = false;
      Console.WriteLine("Server stoped!");
     }
    
    }
    }
