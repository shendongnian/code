        private static TcpChannel channel;
        static void Main(string[] args) {
            BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();
            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = TypeFilterLevel.Full;
            channel = new TcpChannel(
                properties: new Hashtable {
                    { @"port", 2013 }
                },
                clientSinkProvider: clientProv,
                serverSinkProvider: serverProv
            );
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Factory), "Factory.rem", WellKnownObjectMode.SingleCall);
            Console.WriteLine("Server started...");
            Console.WriteLine("Press any key to stop...");
            Console.ReadKey(intercept: true);
        }
