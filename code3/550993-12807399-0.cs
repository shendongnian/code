    public partial class ArtistMetaData
    {
       [Required]
       [StringLength(20)]
       public string Name;//it can be a field instead of a property, must just have the same name and type than in your Model class
    }
