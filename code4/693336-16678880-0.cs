    public class CreatePlaceVM
    {
      [Required]
      public string PlaceName { set;get;}
    
      [Required]
      [Remote("IsExist", "Place", ErrorMessage = "URL exist!")
      public virtual string URL { get; set; }
    }
