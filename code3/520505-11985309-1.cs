    public class Client
    {
        public string Ip { get; set; }
        // More properties if needed
    
        public List<Vote> Votes { get; set; }
    
        public bool ExceedLimitInDay()
        {
        }
    }
    
    public class Vote
    { 
        public int Id { get; set; } 
        public DateTime VoteTime { get; set; } 
        public Article Article { get; set; } 
        public Client { get; set; } 
    }
        
    public class Article   
    {   
        public int Id { get; set; }   
        public string Title { get; set; }   
        public string Content { get; set; }   
    
        public List<Vote> Votes { get; set; }
    
        public bool IsRepeated(string ip)
        {
            return Votes.Select(v => v.Client.Ip == ip).Any();      
        }
    } 
