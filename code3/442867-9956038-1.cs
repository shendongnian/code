    public static void UpdatePacket(Guid packetID, Action<Packet> update)
    {
        using (var ctx = new DataContext())
        {
            var packet = ctx.Packet.SingleOrDefault(p => p.PacketID == packetID);
            update(packet);
            ctx.SubmitChanges();
        }
    }
