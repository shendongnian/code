    var result = targetServerList
                    .GroupBy(s => s.SiteName)
                    .Select(g => new ServersPerSite()
                                {
                                    SiteName = "Site " + g.Key,
                                    ServerNames = string.Join(",", g);
                                });
