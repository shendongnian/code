    class Player
    {
        public string Id { set; get; }
        public int yPos { set; get; }
        public List<Shot> shots;
    
        public Player(string _Id, int _yPos)
        {
            Id = _Id;
            yPos = _yPos;
        }
    
        public void AddShotToYPos()
        {
            shots.Add(new Shot(yPos));
        }
    }
