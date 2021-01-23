    public class Card
    {
        public string suit { get; set; }
        public int value { get; set; }
    
        public static Card GetCard(string cardName)
        {
            string tmpSuit;
            int tmpValue;
            char[] cardNameParts = cardName.ToCharArray();
            switch(charNameParts[0])
            {
                case "A":
                    tmpValue = 1;
                    break;
                case "2":
                    tmpValue = 2;
                    break;
                ...
            }
    
            
            switch(charNameParts[1])
            {
                case "H":
                    tmpSuit= "Hearts";
                    break;
                case "C":
                    tmpSuit= "Clubs";
                    break;
                ...
            }
            return new Card() { suit = tmpSuit, value = tmpValue };
        }
    }
