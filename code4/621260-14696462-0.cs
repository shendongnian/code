    public class Card
    {
        public string suit { get; set; }
        public int number { get; set; }
        public string val
        {
            get
            {
                return number+" of "+suit;
            }
        }
        public override string ToString()
        {
            return val;
        }
    }
