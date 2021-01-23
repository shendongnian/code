    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    
    public class RecvBroadcst
    {
        public static void Main()
        {
           Socket sock = new Socket(AddressFamily.InterNetwork,
                               SocketType.Dgram, ProtocolType.Udp);
         //  int port_no=Convert.ToInt32(sock.RemoteEndPoint);
    
    
             int portnumber = 9050;
    
                sock = new Socket(AddressFamily.InterNetwork,
                               SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint iep = new IPEndPoint(IPAddress.Any,portnumber);
                sock.Bind(iep);
                EndPoint ep = (EndPoint)iep;
                Console.WriteLine("Ready to receive...");
              // int port_no = Convert.ToInt32(sock.RemoteEndPoint);
                while (true)
                {
    
                    byte[] data = new byte[1024];
                    int recv = sock.ReceiveFrom(data, ref ep);
                    string stringData = Encoding.ASCII.GetString(data, 0, recv);
                    Console.WriteLine("received: {0}  from: {1}",
                                          stringData, ep.ToString());
    
                    //data = new byte[1024];
                    //recv = sock.ReceiveFrom(data, ref ep);
                    //stringData = Encoding.ASCII.GetString(data, 0, recv);
                    //Console.WriteLine("received: {0}  from: {1}",
                    //                      stringData, ep.ToString());
    
                    data = null;
                }
                //portnumber--;
               
    
            sock.Close();
        }
    }
