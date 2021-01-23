        Client client = new Client(session);
        client.Connect(server);
        while (true)
        {
            client.SendPacket (new Craft.Net.CreativeInventoryActionPacket(-1, new Craft.Net.ItemStack((short)19, (sbyte)1)));
            client.Disconnect ("Generic");
            System.Threading.Thread.Sleep(3000);
            client = new Client(session); 
            client.Connect(server);
        }
