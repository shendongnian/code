    public class Player
    {
    	public Player()
    	{
    		this.Games = new List<Game>();
    	}
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public List<Game> Games { get; set; }
    }
