    public class PlayerNameComparer : IComparer<Player>
    {
        public void Compare(Player x, Player y)
        {
            // TODO: Handle x or y being null, or them not having names
            return x.Name.CompareTo(y.Name);
        }
    }
