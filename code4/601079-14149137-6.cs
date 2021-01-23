    private struct TeamPair
    {
        private int _team1;
        private int _team2;
        public TeamPair(int team1, int team2)
        {
            _team1 = team1;
            _team2 = team2;
        }
    }
    
    ISet<TeamPair> alliances = new HashSet<TeamPair>(
        new[]{
            new {a=1,b=1},
            new {a=1,b=2},
            new {a=2,b=1},
            new {a=2,b=2},
            new {a=2,b=3},
            // ...
        }.Select(e => new TeamPair(e.a, e.b)));
        
    
    public bool isAllied(int ownF, int oppF) {
        return alliances.Contains(new TeamPair(ownF, oppF));
    }
