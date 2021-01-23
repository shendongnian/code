        static void Main(string[] args)
        {
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpointAddress = new EndpointAddress("net.tcp://localhost:8088/FooBarService");
            // Call IFooService
            var channelFactoryFoo = new ChannelFactory<IFooService>(netTcpBinding, endpointAddress);
            IFooService channelFoo = channelFactoryFoo.CreateChannel();
            Console.WriteLine(channelFoo.FooMethod1());
            // Call IBarService
            var channelFactoryBar = new ChannelFactory<IBarService>(netTcpBinding, endpointAddress);
            IBarService channelBar = channelFactoryBar.CreateChannel();
            Console.WriteLine(channelBar.BarMethod1());
            Console.ReadKey();
        }
