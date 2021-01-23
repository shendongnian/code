        private static void Main(string[] args)
        {
            Dice myRoll = new Dice(1, 7);
            // All the same
            var result1 = myRoll.Rolled.ToString();
            var result2 = myRoll.Rolled.ToString();
            var result3 = myRoll.Rolled.ToString();
            // something new
            var result4 = myRoll.ReRoll.ToString();
            Dice mySecondRoll = new Dice(1, 13);
            var result = mySecondRoll.ReRoll.ToString();
        }
