    public class MatchMaker : Hub
    {    
        private readonly ISoloUserRepository soloUsers;
    
        public MatchMaker(ISoloUserRepository soloUsers) 
        {
            this.soloUsers = soloUsers;
        }
    }
