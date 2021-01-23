    public class LineMap : ClassMap<Line> 
    {
        public LineMap()
        {
            Id(x => x.UID).GeneratedBy.Guid();
            Map(x => x.Number);
            HasMany(x => x.Words)
                .Cascade.All()
                .Inverse();
            References(x => x.Page);
            HasMany(x => x.Polygon)
                .Cascade.All();
        }
    }
    
    public class WordMap : ClassMap<Word>
    {
        public WordMap()
        {
            Id(x => x.UID).GeneratedBy.Guid();
            Map(x => x.Name);
            Map(x => x.Number);
            HasMany(x => x.Polygons)
                .Cascade.All();
            References(x => x.Line);
        }
    }
    
    public class PolygonMap : ClassMap<Polygon>
    {
        public PolygonMap()
        {
            Id(x => x.UID).GeneratedBy.Guid();
            HasMany(x => x.Points)
                .Cascade.All()
                .Inverse();
        }
    }
    
    public class PointMap : ClassMap<Point>
    {
        public PointMap()
        {
            Id(x => x.UID).GeneratedBy.Guid();
            Map(x => x.X);
            Map(x => x.Y);
            References(x => x.Polygon);
        }
    
    }
