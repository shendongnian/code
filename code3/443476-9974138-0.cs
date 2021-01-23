    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    namespace ConsoleApplication3
    {
        class Program
        {
            static string f_WriteIpAddresses()
            {
                IPHostEntry host;
                string localIP = "?";
                string retVal = "";
                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        Console.Write(ip.ToString());
                        Console.Write(" - ");
                        retVal = ip.ToString() + " - "; 
                    }
                }
                return retVal;
            }
            static void Main(string[] args)
            {
                Console.WriteLine("Your IP Address:");
                string oldip = f_WriteIpAddresses();
                Console.Write("[You can delete/modify address]\r");
                string ip = Console.ReadLine();
                string newip = ip + oldip.Substring(ip.Length);
            }
        }
    }
