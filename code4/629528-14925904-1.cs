        static void PrintHostInfo(String host)
        {
            {
                IPHostEntry hostinfo;
                try
                {
                    //Attempt to resolve DNS for given host or address
                    IPAddress[] hostInfo = Dns.GetHostAddresses(host);
                    //Display list of IP addresses for this host
                    Console.WriteLine("\tIP Addresses:  ");
                    foreach (IPAddress ipaddr in hostInfo)
                    {
                        Console.WriteLine("\t\t\t{0} ", ipaddr);
                    }
                    Console.WriteLine("\n-------------------------------------\n\n");
                }
                catch (Exception)
                {
                    Console.WriteLine("\tUnable to resolve host: " + host + "\n");
                }
            }
        }
        static void Main()
        {
            //Get and print local host info
            try
            {
                Console.WriteLine("Local Host:");
                String localHostName = Dns.GetHostAddresses("localhost")[0].ToString();
                Console.WriteLine("\tHost Name:      " + localHostName);
                PrintHostInfo(localHostName);
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to resolve local host\n");
            }
            //Get and print info for hosts given on command line 
            foreach (String arg in new[] { "www.sunybroome.edu" })
            {
                Console.WriteLine(arg + ":");
                PrintHostInfo(arg);
            }
        }
