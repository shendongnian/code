    public class FlowViewModel
    {
    
    	[Key]
    	public string IDv { get; set; }
    	[NotMapped]
    	public SelectList PostesItems { get; set; }	
    	public List<Profile_Ga> Profile_GaItems { get; set; }
    	public List<Gamme> GaItems { get; set; }
    	//here is the gamme member
    	public Gamme YourGammeModel {get;set;}
    
    	public int SelectedProfile_Ga { get; set; }
    
    	public int SelectedGamme{ get; set; }
    
    	public int SelectedPoste { get; set; }
    }
