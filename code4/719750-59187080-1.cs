    public string SearchField { get; private set; }
    public Player(string firstName, string lastName, playersNumber, string team)
    {
    	FirstName = firstName;
    	LastName = lastName;
    	PlayersNumber = playersNumber;
    	Team = team;
    	SearchField = string.Format("{0}{1}{2}{3}",firstName,lastName,playersNumber,team);
    }
