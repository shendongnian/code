    public class FlowViewModel
    {
        [Key]
        public int IDv
        
        ...
        [ForeignKey("SelectedProfile_Ga") // I think this is the relationship
        public virtual Gamme YourGammeModel { get; set; }
        ...
    }
