    public class NewDiscussionModel
        {
            [DataType(DataType.Text)]
            [Required]
            [Display(Name="Title")]
            public string Title {get; set;}
    
            [DataType(DataType.MultilineText)]
            [Required]
            [Display(Name="Message")]
            public string Message{get; set;}
        }
