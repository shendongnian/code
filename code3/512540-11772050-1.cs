    var query = (from db in Setupctx.requiredtimings
                             join timing t in Setupctx.timings on db.RequiredTimingID equals t.TimingID
                             where db.RequiredLocationStationID == selectLocStation
                             select new WrapperClass
                             {
                                 Time = t.Time2
                             }).ToList();
    public class WrapperClass
            {
                public DateTime Time { get; set; }
            }
