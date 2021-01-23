    class UserMetadata
    {
        ...
        [CustomProperty]
        public UserGroup Group { get; set; }
    }
    [MetadataType(typeof(UserMetadata)]
    public class DomainUser : User
    {
    }
 
