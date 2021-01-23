    public static class DiceRoller
    {
        private static Random _roller;
        
        public static void RollDice(Dice dice)
        {
            if (dice.Faces.Count < 1)
                throw new InvalidOperationException("A dice must contain at least 1 side to be rolled.");
    
            if (_roller == null)
                _roller = new Random();
    
            int index = _roller.Next(dice.Faces.Count);
            dice.SetFacingIndex(index);
        }
    }
