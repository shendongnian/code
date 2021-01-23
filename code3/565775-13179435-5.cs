    public class Player
    {
        ...
        public override string ToString()
        {
            return String.Format("Player [ID = {0}, Name = {1}]",
                                 PlayerId, PlayerName);
        }
    { 
