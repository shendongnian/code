    var capaHrs = (
                    from newsPerHr in _dbRawDataContext.CapacityPerHours
                    where newsPerHr.StreamDT >= this.BeginDateTime
                                    && newsPerHr.StreamDT < this.EndDateTime
                                    && newsPerHr.ServerName == this.ServerName
                    group newsPerHr by new { newsPerHr.ServerName, newsPerHr.StreamDT } into grp
                    let MsgSizeTotal = grp.Sum(x => (int)x.MsgSize)
                    let MNumber = grp.Sum(x => (int)x.MsgNumber)
                    let Feeds = (from i in grp select i.FeedName)
                    select new 
                    {
                        ServerName = grp.Key.ServerName,
                        FeedName = Feeds,
                        StreamDT = grp.Key.StreamDT,
                        MsgSize = MsgSizeTotal,
                        MsgNumber = MNumber
                    }).ToList();
    _capacityData = capaHrs.Select(x => new CapacityPerHour {
                    ServerName = x.ServerName,
                    FeedName = string.Join(", ",x.FeedName),
                    StreamDT = x.StreamDT,
                    MsgSize = x.MsgSize,
                    MsgNumber = x.MsgNumber
                }).ToList();
