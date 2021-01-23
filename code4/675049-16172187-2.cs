    public class Monkey : Animal<Monkey>
    {
        public override Monkey GiveBirth()
        {
            return new Monkey();
        }
    }
