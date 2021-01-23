    public class Gallery
    {
       public Guid Id { get; set; }
       public virtual ICollection<PhotoGallery> Photos { get; set; }
    
       [NotMapped]
       public List<PhotoGallery> ActivePhotos 
       { 
          get { return this.Photos.Where(/*condition*/); 
       }
    }
