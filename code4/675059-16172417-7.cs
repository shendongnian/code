    public class Monkey: Animal<WeirdHuman>
    {
        public override Animal<WeirdHuman> GiveBirth()
        {
            return new WeirdHuman();
        }
    }
