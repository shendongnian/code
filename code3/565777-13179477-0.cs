    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string FavoriteThing { get; set; }
        public override string ToString()
        {
            return this.PlayerId.Tostring() + " " + PlayerName + " " + FavoriteThing;
        }
    }
