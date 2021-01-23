    public abstract class BaseEntity {
        ...
        // tags
        public List<Tag> Tags { get; set; }
    }
    
    public class Tag : BaseEntity {
        ...
        // tag subscribers
        public List<BaseEntity> Entities { get; set; }
    }
