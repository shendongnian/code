         public static IGMPv2Packet GetEncapsulated(Packet p)
         {
             if(p is InternetLinkLayerPacket)
             {
                 var payload = InternetLinkLayerPacket.GetInnerPayload((InternetLinkLayerPacket)p);
                 if(payload is IpPacket)
                 {
                     Console.WriteLine("Is an IP packet");
                     var innerPayload = payload.PayloadPacket;
                     if(innerPayload is IGMPv2Packet)
                     {
                         return (IGMPv2Packet)innerPayload;
                     }
                 }
             }
 
             return null;
 
         }
