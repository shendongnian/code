    public static byte[] PacketToArray(Packet packet) {
        using(MemoryStream stream = new MemoryStream()) {
            Serializer.Serialize(stream, packet); // or SerializeWithLengthPrefix
            return stream.ToArray();
        }
    }
