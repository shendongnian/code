        public void ReadIOConfig()
        {
            string fileName = @"C:\IOConfig.xml";
            XmlSerializer xs = new XmlSerializer(typeof(IOConfig));
            XmlReader reader = XmlReader.Create(fileName);
            IOConfig config = xs.Deserialize(reader) as IOConfig;
            var packetOut = (from configPacket in config.Items
                             where configPacket.Name == "PacketOut"
                             select configPacket).First();
            foreach (var signal in packetOut.Signal)
                Console.WriteLine(signal.UnityObject);
        }
