    [TableName("CP_Locations")]
    [PrimaryKey("LocationId", AutoIncrement = true)]
    public class CP_Location
    {
        public int LocationId { get; set; }
        public string LocationType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Long { get; set; }
        public float Lat { get; set; }
        [IgnoreColumn]
        public DbGeography GeoCodeObj { 
            get { return DbGeography.FromText(GeoCode); }
            set { GeoCode = value.AsText(); }
        }
        public string GeoCode { get; protected set; }
    }
