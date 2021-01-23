    //Program.cs
    //C# the final evet consumer application
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GatewayLibrary;
    namespace SharpClient
    {
        class Program
        {
            static void Main(string[] args)
            {
                //create the gateway
                EventGateway gateway = new EventGateway();
                //listen on .net events using the gateway
                gateway.OnEvent += new EventGateway.DotNetEventHandler(gateway_OnEvent);
            }
            static void gateway_OnEvent( DotNetEventArg args )
            {
                //use the argument class
                Console.WriteLine("On Native Event");
                Console.WriteLine(args.ArgInt32);
                Console.WriteLine(args.ArgString);
                Console.WriteLine(args.ArgWString);
            }
        }
    }
