    public class DiceResults
    {
        public DiceResults(int dice1, int dice2, int dice3)
        {
            Dice1 = dice1;
            Dice2 = dice2;
            Dice3 = dice3;
        }
        public int Dice1 { get; private set; }
        public int Dice2 { get; private set; }
        public int Dice3 { get; private set; }
        public int GetBonus()
        {
            int bonus = 0;
            if (AllSixes())
            {
                bonus = 20;
            }
            else if (SetLessThanSix())
            {
                bonus = 10;
            }
            else if (AnyDouble())
            {
                bonus = 5;
            }
            return bonus;
        }
        public bool AllSixes()
        {
            return Dice1 == 6 &&
                   Dice1 == Dice2 &&
                   Dice2 == Dice3;
        }
        public bool SetLessThanSix()
        {
            return Dice1 < 6 &&
                   Dice1 == Dice2 &&
                   Dice2 == Dice3;
        }
        public bool AnyDouble()
        {
            return Dice1 == Dice2 ||
                   Dice2 == Dice3 ||
                   Dice1 == Dice3;
        }
        public int GetDiceTotal()
        {
            return Dice1 + Dice2 + Dice3;
        }
        public int GetPrize(int gamble, int inzet)
        {
            int bonus = GetBonus();
            int prize = bonus;
            if (gamble == GetDiceTotal())
            {
                prize += inzet * 2;
            }
            return prize;
        }
    }
