    public class Photo
    {
      public byte[] Binary { get; set; }
    }
    
    public class ModelWithPhotos
    {
      public virtual IList<Photo> Photos { get; set; }
    }
