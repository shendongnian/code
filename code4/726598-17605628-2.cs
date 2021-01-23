    [TestFixture]
    class EnumFlagsTests
    {
        [Test]
        [TestCase(Environments.HD1 | Environments.HD3)]
        public void ShouldBeTrue(Environments input)
        {
            // arrange
            Environments expectedEnum = (Environments.HD1 | Environments.HD3);
            int expectedNumericalValue = 5;
            
            // assert
            Assert.AreEqual(expectedEnum, input);
            Assert.AreEqual(expectedNumericalValue, (int)input);
        }
    }
    [Flags]
    public enum Environments
    {
        None = 0,
        HD1 = 1 << 0, // 1
        HD2 = 1 << 1, // 2
        HD3 = 1 << 2, // 4	
        HD4 = 1 << 3, // 8
        // etc.
    }
