            return project.Racks.Where(c => c.RackID == id)
                .Select(a => new {
                    serverCount = a.Servers.Count(),
                    dataCenterCount = a.DataCenter.Count(),
                    firewallCount = a.Firewalls.Count(),
                    routerCount = a.Routers.Count(),
                    technologyCount = a.Technology.Count(),
                    storageDeviceCount = a.StorageDevices.Count(),
                    switchCount = a.Switches.Count(),
                    zoneCount = a.Zone.Count()
                }).SingleOrDefault();
