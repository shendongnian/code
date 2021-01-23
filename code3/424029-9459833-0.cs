    class UserScores {
    	
    	public string Key { get; set; }
    	
    	public int User1Score { get; set; }
    	public int User2Score { get; set; }
    	
    	public UserScores(string username1, string username2)
    	{
    			Key = username1 + username2;
    	}
    }
    void Main()
    {
    	var userScore = new UserScores("fooUser", "barUser");
    	
    	var scores = new Dictionary<string, UserScores>();
    	
    	scores.Add(userScore.Key, userScore);
    	
        // Or use a list
    	
    	var list = new List<UserScores>();
    	
    	list.Add(userScore);
    	
    	list.Single (l => l.Key == userScore.Key);
    }
