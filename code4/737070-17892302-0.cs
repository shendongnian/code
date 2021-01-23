    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net.Sockets;
    namespace testtcp {
        class Program {
            static void Main(string[] args) {
                TcpClient client = new TcpClient("www.google.com", 80);
                //client.Connect("www.microsoft.com", 80);
            }
        }
    }
