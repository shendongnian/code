    public class FeatureDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class FeatureGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class FeatureGroupFeaturesDto
    {
        public FeatureGroupDto FeatureGroup { get; set; }
        public IList<FeatureDto> Features { get; set; }
    }
