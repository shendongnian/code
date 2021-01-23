        A simple example is this:
        
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.IO;
        using System.Net;
        using System.Net.Sockets;
        using System.Web;
        using System.Data;
        using System.Collections;
        using System.Collections.Specialized;
        using System.Windows.Forms;
        
        //Some "using" may not be needed
        static public TcpListener listener = new TcpListener(IPAddress.Any, 8080);
        
         static void Main(string[] args)
                {
                 listener.Start();
                 TcpClient client = listener.AcceptTcpClient();
                 StreamReader sr = new StreamReader(client.GetStream());
                 sr.ReadLine();
                }
    
    
    
    **For asynchronous Connection:**
    
    
     static void Main(string[] args)
         {
           client_listener();
         }
    async static public void client_listener()
            {
                while (true)
                {
                    listener.Start();
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    StreamReader sr = new StreamReader(client.GetStream());
                    try
                    {
                        await sr.ReadLineAsync();
                    }
                    catch(Exception e)
                    {
                    }
            }
    }
