    public static void ProcessFriendsOf(string person) {
    	var toVisit = new Queue<string>();
    	var seen = new HashSet<string>();
    	
    	toVisit.Enqueue(person);
    	seen.Add(person);			
    	
    	while(toVisit.Count > 0) {
    		var current = toVisit.Dequeue();	
    		
    		//process this friend in some way
    		
    		foreach(var friend in GetFriendsOfFriend(current)) {
    			if (!seen.Contains(friend)) {
    				toVisit.Enqueue(friend);
    				seen.Add(friend);
    			}
    		}
    	}
    }
