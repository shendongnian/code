    class Dice
    {
        private static Random diceRoller = new Random();
        private int faceofDie;
        public Dice()
        {
            this.RollDice(); // Roll once on construction
        }
        public void RollDice()
        {   
            lock(diceRoller) 
                faceofDie = diceRoller.Next(1, 7);          
        }
        public int FaceOfDie
        {
            get { return faceofDie; }
        }
    }
