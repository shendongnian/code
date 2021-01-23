    [TestClass]
    public class DiceResultsTest
    {
        [TestMethod]
        public void TestDiceTotal()
        {
            //Arrange
            var results = new DiceResults(1, 2, 3);
            //Act
            int diceTotal = results.GetDiceTotal();
            //Assert
            Assert.AreEqual(6, diceTotal);
        }
        [TestMethod]
        public void TestForAllSixes()
        {
            //Arrange
            var results = new DiceResults(6, 6, 6);
            //Assert
            Assert.IsTrue(results.AllSixes());
        }
        [TestMethod]
        public void TestForAllFives()
        {
            //Arrange
            var results = new DiceResults(5, 5, 5);
            //Assert
            Assert.IsTrue(results.SetLessThanSix());
        }
        [TestMethod]
        public void TestForDoubleTwo()
        {
            //Arrange
            var results = new DiceResults(2, 5, 2);
            //Assert
            Assert.IsTrue(results.AnyDouble());
        }
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
        //add more tests to cover all cases.....
    }
