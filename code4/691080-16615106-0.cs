    return list.GroupBy(n => n.ID).Select(g => new NetworkAdapter()
            {
                Description = g.First().Description,
                ID = g.Key,
                IPAddress = string.Join(",", g.Select(v => v.IPAddress)),
                MacAddress = g.First().MacAddress,
                Name = g.First().Name,
                NetworkInterfaceType = g.First().NetworkInterfaceType,
                Speed = g.First().Speed
            }).ToList();
