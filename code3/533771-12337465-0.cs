    public class Post
    {
        [Key]
        public int Id { get; set; }
    
        [Display(Name = "Posted")]
        public DateTime Created { get; set; }
    
        [Display(Name = "Modified")]
        public DateTime? Modified { get; set; }
    
        [Required]
        [MaxLength(256)]
        public string Title { get; set; }
    
        [Required]
        public string Body { get; set; }
    
        public int? UserId { get; set; }
    
        [NotMapped]
        public string UserName { get; set; }
    
        public virtual ICollection<Comment> Comments { get; set; }
    
        public virtual ICollection<Tag> Tags { get; set; } 
    }
