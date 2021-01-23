    var data = segGroups.Join(pPeriods, s => s.segid, p => p.entid, (s, p) => new
                        {
                            Name = s.SegCode, // string
                            Time = p.StartLocal, // datetime
                            TR = p.Volume // double
                        })
                        .GroupBy(s => s.Name)
                        .ToDictionary(g => g.Key, g => g.ToDictionary(i => i.Time, i.TR));
