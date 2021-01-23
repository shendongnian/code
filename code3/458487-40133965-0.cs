    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    
    namespace DescubrimientoDeRed
    {
        //This Class Holds the information for each IP/MAC
        public class IPInfo
        {
            private string _macAddress;
            private string _ipAddress;
    
            public string IpAddress
            {
                get { return _ipAddress; }
                set { _ipAddress = value; }
            }
    
            public string MacAddress
            {
                get { return _macAddress; }
                set { _macAddress = value; }
            }
            
    
            public IPInfo(string pmacAddress, string pipAddress)
            {
                this.MacAddress = pmacAddress;
                this.IpAddress = pipAddress;
            }
            
        }
    
        //This Class holds the IP of each one of the computer interfaces and a list of the
        //IPs/MAC found over that interface
        public class AdaptadorDeRed
        {
            private string _Interfaz;
            private List<IPInfo> _IPsInterfaz;
    
            public List<IPInfo> IPsInterfaz
            {
                get { return _IPsInterfaz; }
                set { _IPsInterfaz = value; }
            }
    
            public string Interfaz
            {
                get { return _Interfaz; }
                set { _Interfaz = value; }
            }
    
            public AdaptadorDeRed(string pInterfaz)
            {
                Interfaz = pInterfaz;
                _IPsInterfaz = new List<IPInfo>();
            }
        }
    
    
        //The following class has the important methods
        public class NetInfo
        {
       
    
            //ARPtheNet
            //This is the procedure that runs the arp command and retruns a text output
            private static string ARPtheNet()
            {
                //this is the process that will run the arp
                Process p = null;
    
                //this string will capture the output
                string output = string.Empty;
    
                try
                {
                    //to the Process we will give the name of the file (wich is the command we use on the cmd and a string with the particular parameters
                    p = Process.Start(new ProcessStartInfo("arp", "-a")
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true
                    });
    
                    //we store the output into the string
                    output = p.StandardOutput.ReadToEnd();
    
                    //then we close te process
                    p.Close();
                }
                catch (Exception ex)
                {
                    //If something goes wrong we throw a message with the name of the failing component, and the exception itself
                    throw new Exception("NetInfo: Error al realizar un ARP a la red", ex);
                }
                finally
                {
                    //whether everithing goes right or wrong, we nedd to close the process..
                    if (p != null)
                    {
                        p.Close();
                    }
                }
                return output;
            }
    
            //This is the procedure that will read the text from the procedure ARPtheNet and create the objects to have a nice result
            public List<AdaptadorDeRed> GetARPTheNet()
            {
                try
                {
                    //This is the list that holds the interfaces (where each one of those, holds the ips)
                    List<AdaptadorDeRed> list = new List<AdaptadorDeRed>();
                    
                    //Need to declare this outside the "ifs" otherwise these objects will not be accesible from all the places i need.
                    AdaptadorDeRed adr = null;
                    IPInfo ipi = null;
                    
    
                    //Line by Line we move throw the text of the ARPtheNet result
                    foreach (var arp in ARPtheNet().Split(new char[] { '\n', '\r' }))
                    {
                        //if the strings has texto on it...
                        if (!string.IsNullOrEmpty(arp))
                        {
                            //If the text has a ":", means that this line has the IP of the particular Interface like:
                            //Interface: 192.168.0.1 --- 0x17 that means either is the first interface we have found, 
                            //or we already have an interface with ips and we have found a new one. 
                            if (arp.IndexOf(":") > 1)
                            {
                                //So if the interfaces is not null and have IPs, we add it to the list and set it null in order to create a new one for the one we just found.
                                if (adr != null && adr.IPsInterfaz.Count > 0)
                                {
                                    list.Add(adr);
                                    adr = null;
                                }
                                //either way, we create a new adapter
                                adr = new AdaptadorDeRed(arp.Substring(10, arp.IndexOf("---") - 11));
                            }
                            else 
                            {
                                //Need to split the line in as many spaces or tabs we found.
                                var pieces = (from piece in arp.Split(new char[] { ' ', '\t' })
                                              where !string.IsNullOrEmpty(piece)
                                              select piece).ToArray();
                                //the onew that has 3 pieces is because the are like "192.168.0.1", "ff-ff-ff-ff-ff", "Dinamyc".
                                if (pieces.Length == 3)
                                { 
                                    //we add it to the list of the particular interface
                                    adr.IPsInterfaz.Add(new IPInfo(pieces[1], pieces[0]));
                                }
                            }
                        }
                    }
    
                    //When we get to the end of the text, we are not going to find another ":", so if the adapter is not null and has ips on it we need to add it to the list. 
                    if (adr != null && adr.IPsInterfaz.Count > 0) list.Add(adr);
                    //then we return the list.
                    return list;
    
                }
                catch (Exception ex)
                {
                    throw new Exception("GetARPTheNet: Error al recuperar datos", ex);
                }
    
            }
           
        }
    }
    
       
