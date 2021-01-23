    public class FlowViewModel
        {
    
            [Key]
            public string IDv { get; set; }
    
            [NotMapped]
            public SelectList GenreItems { get; set; }
              public string SelectedGenre { get; set; } 
       }
        
