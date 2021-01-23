    // Added Flags attribute.
    [Flags]
    public enum ACL
    {
        None = 0,
        Create = 1,
        Delete = 2,
        Edit = 4,
        Update = 8,
        Execute = 16
    }
    
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // ACLItems is not List anymore.
        public ACL ACLItems { get; set; }
    }
