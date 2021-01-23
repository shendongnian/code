    public abstract class BaseEntity
    {
        /// <summary>
        /// The unique identifier for this BaseEntity.
        /// </summary>
        [Key]        
        public Guid Id { get; set; }
    }
    public class Event : BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(256)]
        public string Name { get; set; }
        public HashSet<Manager> Managers { get; set; }
    }
    public class Manager : BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(256)]
        public string Name { get; set; }
        public Event Event{ get; set; }
    }
