        public class FlowViewModel
        {
            public FlowViewModel()
            {
                PostesItems = new List<Poste>()
            }
            [Key]
            public string IDv { get; set; }
            public List<Poste> PostesItems { get; set; }
            public List<Profile_Ga> Profile_GaItems { get; set; }
            public List<Gamme> GaItems { get; set; }
    
            public int SelectedProfile_Ga { get; set; }
    
            public int SelectedGamme{ get; set; }
            
            public int SelectedPoste { get; set; }
        }    
