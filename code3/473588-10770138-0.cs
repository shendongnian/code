         var xPackets = 15;
         var interval = TimeSpan.FromSeconds(15);
         var ips =
            allPackets
               .GroupBy(
                  p => p.sourceIp,
                  (ip, packets) => new
                                      {
                                         ip,
                                         packets = packets.OrderBy(p => p.arrivalDate).ToList()
                                      })
               .ToList();
         var rapidIps = new List<string>();
         foreach (var ipPacket in ips)
         {
            for (int i = 0, j = xPackets; j < ipPacket.packets.Count; i++, j++)
            {
               if (ipPacket.packets[i].arrivalDate + interval >= ipPacket.packets[j].arrivalDate)
                  rapidIps.Add((ipPacket.ip));
            }
         }
