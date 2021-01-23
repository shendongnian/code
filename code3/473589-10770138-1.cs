      List<Packet> allPackets =
         new List<Packet>
            {
               new Packet {arrivalDate = DateTime.Parse("2000-01-01 0:00:00"), sourceIp = "a"},
               new Packet {arrivalDate = DateTime.Parse("2000-01-01 0:00:01"), sourceIp = "a"},
               new Packet {arrivalDate = DateTime.Parse("2000-01-01 0:00:01"), sourceIp = "a"},
               new Packet {arrivalDate = DateTime.Parse("2000-01-01 0:01:00"), sourceIp = "a"},
               new Packet {arrivalDate = DateTime.Parse("2000-01-01 0:00:00"), sourceIp = "b"},
               new Packet {arrivalDate = DateTime.Parse("2000-01-01 0:01:00"), sourceIp = "b"},
               new Packet {arrivalDate = DateTime.Parse("2000-01-01 0:02:00"), sourceIp = "b"},
               new Packet {arrivalDate = DateTime.Parse("2000-01-01 0:03:00"), sourceIp = "b"},
            };
      var xPackets = 2;
      var interval = TimeSpan.FromSeconds(15);
      // We group all the packets by ip, then within that, order the packets by date.
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
      // Build a list of IPs with at least x packets in y interval.
      var rapidIps = new List<string>();
      foreach (var ipPacket in ips)
      {
         for (int i = 0, j = xPackets; j < ipPacket.packets.Count; i++, j++)
         {
            if (ipPacket.packets[i].arrivalDate + interval >= ipPacket.packets[j].arrivalDate)
            {
               rapidIps.Add((ipPacket.ip));
               break;
            }
         }
      }
