            var newsam = sam.Select(s => new
                                        {
                                            id = s.id,
                                            name = s.name,
                                            list = s.list.Select(l => eList.FirstOrDefault(e => e.id == l).text).ToList()
                                        })
                            .ToList();
