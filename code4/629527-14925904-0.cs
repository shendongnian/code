        static void PrintHostInfo(String host)
        {
            {
                IPHostEntry hostinfo;
                try
                {
                    IPHostEntry hostInfo;
                    //Attempt to resolve DNS for given host or address
                    hostInfo = Dns.GetHostEntry(host);
                    //Display the primary host name
                    Console.WriteLine("\tCanonical Name: " + hostInfo.HostName);
                    //Display list of IP addresses for this host
                    Console.WriteLine("\tIP Addresses:  ");
                    foreach (IPAddress ipaddr in hostInfo.AddressList)
                    {
                        Console.WriteLine("\t\t\t{0} ", ipaddr);
                    }
                    Console.WriteLine();
                    //Display list of alias names for this host
                    Console.Write("\tAliases:       ");
                    foreach (String alias in hostInfo.Aliases)
                    {
                        Console.Write(alias + " ");
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
                String localHostName = Dns.GetHostName();
                Console.WriteLine("\tHost Name:      " + localHostName);
                PrintHostInfo(localHostName);
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to resolve local host\n");
            }
            //Get and print info for hosts given on command line 
            foreach (String arg in new[] {"google.com", "yahoo.com"})
            {
                Console.WriteLine(arg + ":");
                PrintHostInfo(arg);
            }
        }
