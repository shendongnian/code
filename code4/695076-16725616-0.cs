    public class FlowViewModel
    {
        [Key]
        public string IDv { get; set; }
        public List<Famille> FaItems { get; set; }
        public List<Sous_Famille> SFItems { get; set; }
        [NotMapped]
        public SelectList GenreItems { get; set; }
        public string SelectedGenre { get; set; } 
        public FlowViewModel()
        {
            FaItems = new List<Famille>();
            SFItems = new List<Sous_Famille>();
        }
    }
