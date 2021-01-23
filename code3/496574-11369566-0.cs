    using System;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Collections.Generic;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    
    namespace NetworkPing
    {
        class Program
        {
    
            private static int _Timeout = 120;
            private static int nextLine = 0;
            
            public static void Main(string[] args)
            {
                Console.WriteLine("NetworkPing!");
                
                //check if any command line arguments have been supplied
                if (args.Length > 0)
                {
                    //parse the the arguments
                    foreach ( string arg in args)
                    {
                        switch( arg[1].ToString() )
                        {
                            case "?":
                                {
                                    //display help topic
                                    DisplayHelp();
                                }
                            break;
                                
                            case "t":
                                {
                                    //change the timout
                                    _Timeout = Int32.Parse( GetParameter(arg) );
                                    Console.WriteLine("Ping timeout set to {0}ms", _Timeout);
                                }
                            break;
                        }    
                    }
                }
                
                
                DateTime startTime = DateTime.Now;
                
                IPAddress[] Adresses2 = GetAllUnicastAddresses();
                foreach (IPAddress Adres in Adresses2)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Local IP Address: {0}", Adres);
                    Console.WriteLine("Scanning IP from {0}.1 to {0}.254, awaiting results...", NetworkAddress(Adres) );
    
                    nextLine = Console.CursorTop;
                
                    Task[] tasks = new Task[254];
                
                    for (int i = 0; i != 254; i++)
                    {
                        //calculate the IP address for the ping
                        string ipAddressToPing = NetworkAddress( Adres ) + "." + (i+1);
                        //ping the address and check the response
                        tasks[ i ] = Task.Factory.StartNew( () => PingAddress(ipAddressToPing) );
                    }
                                    
                    //Block until all tasks complete.
                    Task.WaitAll(tasks);
                    
                }
                
                TimeSpan ts = DateTime.Now - startTime;
                Console.WriteLine("");            
                Console.WriteLine("Scan complete in {0} seconds, Press any key to continue...", ts.Seconds);
                Console.ReadKey();
            }
    
            private static string GetParameter( string Argument )
            {
                return Argument.Substring( Argument.LastIndexOf(":") +1);
            }
            
            public static void DisplayHelp()
            {
                Console.WriteLine("Usage: PingNetwork [/?] or [-?] [-t:Timeout]");
                Console.WriteLine("");
                Console.WriteLine("  {0,-12} {1}","/?","Display these usage instructions");
                Console.WriteLine("  {0,-12} {1}","-?","Display these usage instructions");
                Console.WriteLine("  {0,-12} {1}","-t:timeout","Changes the default timout from 120ms");
                Console.WriteLine("");
            }
            
            public static IPAddress[] GetAllUnicastAddresses()
            {
                // This works on both Mono and .NET , but there is a difference: it also
                // includes the LocalLoopBack so we need to filter that one out
                List<IPAddress> Addresses = new List<IPAddress>();
                // Obtain a reference to all network interfaces in the machine
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in adapters)
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    foreach (IPAddressInformation uniCast in properties.UnicastAddresses)
                    {
                        // Ignore loop-back, IPv6 and link-local
                        if (!IPAddress.IsLoopback(uniCast.Address) && uniCast.Address.AddressFamily!= AddressFamily.InterNetworkV6 && !uniCast.Address.ToString().StartsWith("169.254.") )
                            Addresses.Add(uniCast.Address);
                    }
                    
                }
                return Addresses.ToArray();
            }
            
            private static void PingAddress( string IPAddress )
            {
                Ping pingSender = new Ping ();
                PingOptions options = new PingOptions ();
    
                // Use the default Ttl value which is 128,
                // but change the fragmentation behavior.
                options.DontFragment = true;
    
                // Create a buffer of 32 bytes of data to be transmitted.
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = System.Text.Encoding.ASCII.GetBytes (data);
                
                PingReply reply = pingSender.Send(IPAddress, _Timeout, buffer, options);
                
                if (reply.Status == IPStatus.Success)
                {
                       //set the cursor to the next line
                    Console.CursorTop = nextLine;
                    //        
                    Console.WriteLine( IPAddress + " :OK");
                    //
                    nextLine++;
                }
            }
            
            
            private static string NetworkAddress( IPAddress Address )
            {
                string ipAddress = Address.ToString();
                return ipAddress.Substring( 0, ipAddress.LastIndexOf(".") );
            }
            
            private static string LastOctet( IPAddress Address )
            {
                string ipAddress = Address.ToString();
                return ipAddress.Substring( ipAddress.LastIndexOf(".") );
            }
            
            private static int _cursorX;
            private static int _cursorY;
            
            private static void GetCursor()
            {
                _cursorX = Console.CursorLeft;
                _cursorY = Console.CursorTop;
            }
                
            private static void SetCursor()
            {
                Console.CursorLeft = _cursorX;
                Console.CursorTop = _cursorY;
            }
            
        }
    } 
