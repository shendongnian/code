    public class Player
    {
    	public string SearchField { get => string.Format("{0}{1}{2}{3}",FirstName,LastName,PlayersNumber,Team); }
    	
    	public string FirstName {get; set;}
    	
    	public string LastName {get; set;}
    	
    	public string PlayersNumber {get; set;}
    	
    	public string Team {get; set;}
    }
