    public class News : IStorable
    {
        [Required]
        [Display(Name = "Title")]
        public virtual string Title { get; set; }
        [Required()]
        [Display(Name = "Content")]
        [DataType(DataType.MultilineText)]
        public virtual string NewsContent { set; get; }
        //....
    }
