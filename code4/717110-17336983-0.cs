    public class BlackJackTable : TableGame
    {
        // If other classes need access to this I'd set it up as public
        // property, not a public field.  If not, I'd set the field to
        // private
        public override BettingSpot[] bettingSpotArray = new BettingSpot[5];
        public BlackJackTable(int tableNumber)
        {
            // I don't see a _tableNumber field in your abstract class or your 
            // inheriting class - if you don't have that field you'll get an error
            // in the compiler
            _tableNumber = tableNumber;
        }
        // Your posted code had public override void BlackJackRules, but there is
        // no BlackJackRules() method to override
        public override void Rules()
        {  
            // These are superfulous since you'll be using an array
            // for the betting spots
            //BettingSpot spot1 = new BettingSpot(1);
            //BettingSpot spot2 = new BettingSpot(2);
            //BettingSpot spot3 = new BettingSpot(3);
            //BettingSpot spot4 = new BettingSpot(4);
            //BettingSpot spot5 = new BettingSpot(5);
            //BettingSpot spot6 = new BettingSpot(6);
            // Now you can initialize your array
            for (int i = 0; i < bettingSpotArray.Length; i++)
            {
                 bettingSpotArray[i] = new BettingSpot[i+1];
            }
        }
    }
