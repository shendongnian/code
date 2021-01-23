    namespace Models
    {
        [MetadataType(typeof(UserSearchMetadata))]
        public partial class UserSearch
        {
            //some class
        }
        public class UserSearchMetadata
        {
            [Required] //required attribute
            public string SearchString {get;set;}
        }
    }
