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
        private bool AllSixes()
        {
            return Dice1 == 6 &&
                   Dice1 == Dice2 &&
                   Dice2 == Dice3;
        }
        private bool SetLessThanSix()
        {
            return Dice1 < 6 &&
                   Dice1 == Dice2 &&
                   Dice2 == Dice3;
        }
        private bool AnyDouble()
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
    [TestClass]
    public class DiceResultsTest
    {
        [TestMethod]
        public void TestBonusForAllSixes()
        {
            //Arrange
            var results = new DiceResults(6, 6, 6);
            //Act
            int bonus = results.GetBonus();
            //Assert
            Assert.AreEqual(20, bonus);
        }
        [TestMethod]
        public void TestBonusForAllFives()
        {
            //Arrange
            var results = new DiceResults(5, 5, 5);
            //Act
            int bonus = results.GetBonus();
            //Assert
            Assert.AreEqual(10, bonus);
        }
        [TestMethod]
        public void TestBonusForDoubleTwo()
        {
            //Arrange
            var results = new DiceResults(2, 5, 2);
            //Act
            int bonus = results.GetBonus();
            //Assert
            Assert.AreEqual(5, bonus);
        }
        [TestMethod]
        public void TestBonusWhenNoBonus()
        {
            //Arrange
            var results = new DiceResults(1, 2, 3);
            //Act
            int bonus = results.GetBonus();
            //Assert
            Assert.AreEqual(0, bonus);
        }
        [TestMethod]
        public void TestPrizeForAllSixesAndCorrectGamble()
        {
            //Arrange
            var results = new DiceResults(6, 6, 6);
            //Act
            var prize = results.GetPrize(18, 50);
            //Assert
            Assert.AreEqual(120, prize);
        }
        [TestMethod]
        public void TestPrizeForAllSixesAndIncorrectGamble()
        {
            //Arrange
            var results = new DiceResults(6, 6, 6);
            //Act
            var prize = results.GetPrize(15, 50);
            //Assert
            Assert.AreEqual(20, prize);
        }
    }
