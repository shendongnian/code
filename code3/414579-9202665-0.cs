    public abstract class Player : IComparable
    {
        public abstract int Skill { get; }
        public int CompareTo(object obj)
        {
            if (obj is Player)
                return this.Skill.CompareTo(((Player) obj).Skill);
            throw new ArgumentException();
        }
    }
    public class Warrior : Player
    {
        public override int Skill
        {
            get { return 3; }
        }
    }
    public class Destroyer : Player
    {
        public override int Skill
        {
            get { return 4; }
        }
    }
    public class Game
    {
        public Player Attacker { get; set; }
        public Player Opponent { get; set; }
        public bool AttackerWins
        {
            get { return Attacker.CompareTo(Opponent) == 1; }
        }
        public bool OpponentWins
        {
            get { return Opponent.CompareTo(Attacker) == 1; }
        }
    }
