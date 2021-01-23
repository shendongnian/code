    public class MyClass
    {
        public MyClass(int trackPointId, DateTime trackTime, ...)
        {
            TrackPointId = trackPointId;
            TrackTime = trackTime;
            ...
        }
        public int TrackPointId { get; set; }
        public DateTime TrackTime { get; set }
        ...
    }
    List<MyClass> result  = (from r in aspdb.Routes
                  where r.UserId == userId
                  join t in aspdb.TrackPoints on r.RouteId equals t.RouteFK
                  select new MyClass(t.TrackPointId,t.RouteFK,t.TrackTime,t.Longitude,t.Latitude,t.Elevation, r.SourceName);
       
