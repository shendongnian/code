    [ProtoContract]
    class Player
    {
        [ProtoMember(1)]
        public string Name { get; private set; }
        [ProtoMember(2)]
        public int Ammo { get; private set; }
        [ProtoMember(3)]
        public string Position { get; private set; }
    
        private Player() { }
    
        public Player(string name, int ammo, string position)
        {
            this.Name = name;
            this.Ammo = ammo;
            this.Position = position;
        }
    }
