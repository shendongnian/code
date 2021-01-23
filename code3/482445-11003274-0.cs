    class DiceRoller
    {
        int DiceRoll = 0;
        Random RandomNumber = new Random();
    
        public DiceRoller()
        {
           int DiceRoll = RandomNumber.Next(1, 20);
        }
    
       public int getDiceRoll()
       {
          return DiceRoll;
       }
    }
