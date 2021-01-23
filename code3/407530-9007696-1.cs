    public class LocationMap : ClassMap<Location>
     {
        public LocationMap()
        {
            Table("Locations");
            Id(x => x.locationID).Column("ID");
            HasMany(x => x.LocationTimes).KeyColumn("LID").Inverse().Cascade.All();
