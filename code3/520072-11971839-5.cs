    DataPacket packet;
    packet.Id = 1234;
    packet.Name = "Marvin the paranoid robot";
    packet.Grade = 9.2;
    // serialize
    var bytes = packet.Serialize();
    // send via tcp
    var tcp = new TcpClient(...); 
    tcp.GetStream().Write(bytes, 0, bytes.Length);
   
    // deserializing;
    DataPacket receivedPacket;
    receivedPacket.deserialize(bytes);
   
 
