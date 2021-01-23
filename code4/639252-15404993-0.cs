    public class Gallery : Entity
    {
        public virtual IList<UIItem> GalleryItems { get; set; }
    }
    
    public class UIItem : Entity
    {
        public virtual Gallery Gallery { get; set; }
    }
